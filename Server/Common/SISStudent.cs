using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common
{
    public class SISStudent
    {
        [JsonProperty("data")]
        public SISStudentData Data { get; set; }
    }

    public class SISStudentData
    {
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("credentials")]
        public SISStudentDataCredentials Credentials { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("dob")]
        public string DOB { get; set; }

        [JsonProperty("ell_status")]
        public string EllStatus { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("frl_status")]
        public string FrlStatus { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("grade")]
        public string Grade { get; set; }

        [JsonProperty("hispanic_ethnicity")]
        public string HispanicEthnicity { get; set; }

        [JsonProperty("iep_status")]
        public string IepStatus { get; set; }

        [JsonProperty("last_modified")]
        public string LastModified { get; set; }

        [JsonProperty("location")]
        public SISStudentDataLocation Location { get; set; }

        [JsonProperty("name")]
        public SISStudentDataName Name { get; set; }

        [JsonProperty("school")]
        public string School { get; set; }

        [JsonProperty("sis_id")]
        public string SisId { get; set; }

        [JsonProperty("state_id")]
        public string StateId { get; set; }

        [JsonProperty("student_number")]
        public string StudentNumber { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class SISStudentDataCredentials
    {
        [JsonProperty("district_username")]
        public string DistrictUsername { get; set; }
    }

    public class SISStudentDataLocation
    {
        [JsonProperty("zip")]
        public string Zip { get; set; }
    }

    public class SISStudentDataName
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }
    }
}
