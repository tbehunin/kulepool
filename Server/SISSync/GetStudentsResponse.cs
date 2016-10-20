using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace SISSync
{
    public class GetStudentsResponse
    {
        [JsonProperty("data")]
        public List<SISStudent> Data { get; set; }
    }
}
