using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Dal;
using Dal.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SISSync;

namespace SISSyncConsole
{
    public class Program
    {
        private IDistrictsRepository _districtsRepo;
        private ISchoolsRepository _schoolsRepo;

        public Program()
        {
            _districtsRepo = new DistrictsRepository();
            _schoolsRepo = new SchoolsRepository();
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
                var district = dbDistricts.FirstOrDefault(x => x.ExternalId.ToLower().Equals(sisDistrict.Data.Id.ToLower()));
                if (district == null)
                {
                    district = new District
                    {
                        ExternalId = sisDistrict.Data.Id,
                        Name = sisDistrict.Data.Name,
                        SyncState = new SyncState
                        {
                            BookmarkId = string.Empty,
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
                        var sisSchool = sisSchoolsResp.Data.FirstOrDefault(x => x.Data.Id.ToLower().Equals(district.ExternalId.ToLower()));

                        if (sisSchool == null)
                        {
                            // District stopped sharing the school..?
                            // todo: mark this district as inactive?
                            continue;
                        }

                        // Now map the new values to the db object
                        school.Address = sisSchool.Data.Location;
                        school.District = district;
                        school.ExternalId = sisSchool.Data.Id;
                        school.HighGrade = sisSchool.Data.HighGrade;
                        school.LowGrade = sisSchool.Data.LowGrade;
                        school.Name = sisSchool.Data.Name;
                        school.PhoneNumber = sisSchool.Data.Phone;
                    }

                    // Add new ones
                    foreach (var sisSchool in sisSchoolsResp.Data.Where(x => !dbSchools.Any(y => y.ExternalId == x.Data.Id)))
                    {
                        dbSchools.Add(new School
                        {
                            Address = new PhysicalLocation
                            {
                                Address = sisSchool.Data.Location.Address,
                                City = sisSchool.Data.Location.City,
                                State = sisSchool.Data.Location.State,
                                ZipCode = sisSchool.Data.Location.ZipCode
                            },
                            District = district,
                            ExternalId = sisSchool.Data.Id,
                            HighGrade = sisSchool.Data.HighGrade,
                            LowGrade = sisSchool.Data.LowGrade,
                            Name = sisSchool.Data.Name,
                            PhoneNumber = sisSchool.Data.Phone
                        });
                    }

                    _schoolsRepo.BulkSave(dbSchools);
                    Console.WriteLine("foo");
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

        private void ProcessSchoolsFullSync(SISDistrict sisDistrict, District district)
        {
            // Set Sync status
            //district.SyncState.SyncSchoolsStatus = SyncStatuses.RetrievingData;
            //_districtsRepo.Save(district);

            //// Batch get all schools for district from clever
            //var sisSchoolsResp = JsonConvert.DeserializeObject<GetSchoolsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\schools.json"));

            //// Batch get all schools for district from db
            //var dbSchools = _schoolsRepo.List($"{{districtId: \"{district.Id}\"}}");

            //// after match, then
        }

        private void ProcessTeachersFullSync()
        {

        }

        private void ProcessStudentsFullSync()
        {

        }

        private void ProcessSectionsFullSync()
        {

        }
    }
}
