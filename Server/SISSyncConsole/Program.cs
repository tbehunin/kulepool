using System;
using System.IO;
using System.Linq;
using Dal;
using Dal.Entities;
using MongoDB.Driver;
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
            var client = new MongoClient();
            var db = "kulepool";
            _districtsRepo = new DistrictsRepository(client, db);
            _schoolsRepo = new SchoolsRepository(client, db);
            _studentsRepo = new StudentsRepository(client, db);
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
                    var sisSchools = JsonConvert.DeserializeObject<GetSchoolsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\schools.json")).Data;
                    _schoolsRepo.SyncSchools(district, sisSchools);

                    var dbSchools = _schoolsRepo.List($"{{'district._id':ObjectId('{district.Id}')}}");
                    foreach (var school in dbSchools)
                    {
                        var sisStudents = JsonConvert.DeserializeObject<GetStudentsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\students.json"))
                            .Data.Where(x => x.Data.School.Equals(school.SISData.Data.Id)).ToList(); // simulate getting students from each school
                        _studentsRepo.SyncStudents(district, school, sisStudents);
                    }

                    // Now mark the district as syncing via events
                    // todo
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
