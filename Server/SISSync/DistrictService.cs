using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISSync
{
    public class DistrictService
    {
        public string Get(string authToken)
        {
            var client = new RestClient("https://api.clever.com");
            var req = new RestRequest("v1.1/districts", Method.GET);
            req.AddHeader("Authorization", "Bearer DEMO_TOKEN");
            var response = client.Get(req);
            return response.Content.ToString();
        }
    }
}
