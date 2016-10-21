using System;
using System.IO;
using System.Linq;
using Dal;
using Dal.Entities;
using Newtonsoft.Json;
using SISSync;

namespace SISSyncConsole
{
    public class Program
    {
        private IDistrictsRepository _districtsRepo;
        private ISchoolsRepository _schoolsRepo;
        private IStudentsRepository _studentsRepo;

        public Program()
        {
            _districtsRepo = new DistrictsRepository();
            _schoolsRepo = new SchoolsRepository();
            _studentsRepo = new StudentsRepository();
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            Console.WriteLine("Finished. Press <enter> to exit.");
            Console.ReadLine();
        }

        public void Run()
        {
            // Call Clever to get list of all districts that share
            var sisDistrictsResp = JsonConvert.DeserializeObject<GetDistrictsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\districts.json"));

            // Query the DB to get list of existing districts
            var dbDistricts = _districtsRepo.List();

            // Loop through the other way
            foreach (var sisDistrict in sisDistrictsResp.Data)
            {
                // Match the corresponding db district
                var district = dbDistricts.FirstOrDefault(x => x.SISData.Data.Id.Equals(sisDistrict.Data.Id));
                if (district == null)
                {
                    district = new District
                    {
                        ExternalId = sisDistrict.Data.Id,
                        SISData = sisDistrict,
                        SyncState = new SyncState
                        {
                            FullSync = true
                        }
                    };
                    _districtsRepo.Save(district);
                }

                if (district.SyncState.FullSync || string.IsNullOrWhiteSpace(district.SyncState.BookmarkId))
                {
                    // Get all schools from Clever and from the db
                    var sisSchoolsResp = JsonConvert.DeserializeObject<GetSchoolsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\schools.json"));
                    var dbSchools = _schoolsRepo.List($"{{'District._id':ObjectId('{district.Id}')}}");

                    foreach (var school in dbSchools)
                    {
                        // Match the corresponding clever school
                        var sisSchool = sisSchoolsResp.Data.FirstOrDefault(x => x.Data.Id.Equals(school.SISData.Data.Id));

                        if (sisSchool == null)
                        {
                            // District stopped sharing the school..?
                            // todo: mark this district as inactive?
                            continue;
                        }

                        // Now map the new values to the db object
                        school.District = district;
                        school.ExternalId = sisSchool.Data.Id;
                        school.SISData = sisSchool;
                    }

                    // Add new schools
                    foreach (var sisSchool in sisSchoolsResp.Data.Where(x => !dbSchools.Any(y => y.SISData.Data.Id == x.Data.Id)))
                    {
                        dbSchools.Add(new School
                        {
                            District = district,
                            ExternalId = sisSchool.Data.Id,
                            SISData = sisSchool
                        });
                    }
                    _schoolsRepo.BulkSave(dbSchools);

                    foreach (var school in dbSchools)
                    {
                        // Get all students from Clever and from the db
                        var sisStudents = JsonConvert.DeserializeObject<GetStudentsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\students.json"))
                            .Data.Where(x => x.Data.School.Equals(school.SISData.Data.Id)).ToList(); // simulate getting students from each school
                        var dbStudents = _studentsRepo.List($"{{'School._id':ObjectId('{school.Id}')}}");

                        foreach (var student in dbStudents)
                        {
                            // Match the corresponding clever student
                            var sisStudent = sisStudents.FirstOrDefault(x => x.Data.Id.Equals(student.SISData.Data.Id));

                            if (sisStudent == null)
                            {
                                // Student left the school..?
                                // todo: mark this student as inactive?
                                continue;
                            }

                            // Now map the new values to the db object
                            student.District = district;
                            student.ExternalId = sisStudent.Data.Id;
                            student.School = school;
                            student.SISData = sisStudent;
                        }

                        // Add new students
                        foreach (var sisStudent in sisStudents.Where(x => !dbStudents.Any(y => y.SISData.Data.Id == x.Data.Id)))
                        {
                            dbStudents.Add(new Student
                            {
                                District = district,
                                ExternalId = sisStudent.Data.Id,
                                School = school,
                                SISData = sisStudent
                            });
                        }
                        _studentsRepo.BulkSave(dbStudents);
                    }
                }
                else
                {
                    // Sync Events
                }
            }

            // Update the list of existing districts
            /*dbDistricts = _districtsRepo.List();

            foreach (var district in dbDistricts)
            {
                // Match the corresponding clever district
                var sisDistrict = sisDistrictsResp.Data.FirstOrDefault(x => x.Data.Id.ToLower().Equals(district.Id.ToLower()));

                if (sisDistrict == null)
                {
                    // District stopped sharing..?
                    // todo: mark this district as inactive?
                    continue;
                }
            }*/
        }
    }
}
