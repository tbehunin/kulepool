using System.Collections.Generic;
using Common;
using Newtonsoft.Json;

namespace SISSync
{
    public class GetStudentsResponse
    {
        public List<SISStudent> Data { get; set; }
    }
}
