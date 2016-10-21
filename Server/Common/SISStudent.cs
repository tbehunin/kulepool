using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common
{
    public class SISStudent
    {
        public SISStudentData Data { get; set; }
    }

    public class SISStudentData
    {
        public string Created { get; set; }
        
        public SISStudentDataCredentials Credentials { get; set; }
        
        public string District { get; set; }
        
        public string DOB { get; set; }

        [JsonProperty("ell_status")]
        public string EllStatus { get; set; }
        
        public string Email { get; set; }

        [JsonProperty("frl_status")]
        public string FrlStatus { get; set; }
        
        public string Gender { get; set; }
        
        public string Grade { get; set; }

        [JsonProperty("hispanic_ethnicity")]
        public string HispanicEthnicity { get; set; }

        [JsonProperty("iep_status")]
        public string IepStatus { get; set; }

        [JsonProperty("last_modified")]
        public string LastModified { get; set; }
        
        public SISStudentDataLocation Location { get; set; }
        
        public SISStudentDataName Name { get; set; }
        
        public string School { get; set; }

        [JsonProperty("sis_id")]
        public string SisId { get; set; }

        [JsonProperty("state_id")]
        public string StateId { get; set; }

        [JsonProperty("student_number")]
        public string StudentNumber { get; set; }

        public string Id { get; set; }
    }

    public class SISStudentDataCredentials
    {
        [JsonProperty("district_username")]
        public string DistrictUsername { get; set; }
    }

    public class SISStudentDataLocation
    {
        public string Zip { get; set; }
    }

    public class SISStudentDataName
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }
    }
}
