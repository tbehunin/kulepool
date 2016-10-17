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
            // First call Clever to get list of all districts that share
            var sisResp = JsonConvert.DeserializeObject<GetDistrictsResponse>(File.ReadAllText(@"C:\dev\kulepool\Server\SISSyncConsole\districts.json"));

            Console.WriteLine("hi");
            // Now call the DB to get a list of existing records
            //var dbDistricts = _districtsRepo.List("");

            //var list = sisDistricts["data"];
            //foreach (var item in list)
            //{
            //    var district = item["data"];
            //    Console.WriteLine(district["name"]);
            //}
        }
    }
}
