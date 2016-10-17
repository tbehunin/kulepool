using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dal;
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

                if (district.FullSync)
                {
                    // Batch get all schools for district from clever
                    var sisSchoolsResp = JsonConvert.DeserializeObject<GetSchoolsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\schools.json"));

                    // Batch get all schools for district from db
                    var dbSchools = _schoolsRepo.List($"{{districtId: \"{district.Id}\"}}");

                    // after match, then
                }
                else
                {
                    // Sync Events
                }

                // Mark this district as completed
                sisDistrict.Synced = true;
            }

            // Loop through the other way
            foreach(var sisDistrict in sisDistrictsResp.Data.Where(x => !x.Synced))
            {
                //
            }
        }
    }
}
