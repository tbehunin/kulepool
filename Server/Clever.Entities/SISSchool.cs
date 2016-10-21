using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Clever.Entities
{
    public class SISSchool
    {
        public SISSchoolData Data { get; set; }

        public string Uri { get; set; }
    }

    public class SISSchoolData
    {
        public string Created { get; set; }

        public string District { get; set; }

        [JsonProperty("high_grade")]
        [BsonElement("high_grade")]
        public string HighGrade { get; set; }

        [JsonProperty("last_modified")]
        [BsonElement("last_modified")]
        public string LastModified { get; set; }

        public SISSchoolDataLocation Location { get; set; }

        [JsonProperty("low_grade")]
        [BsonElement("low_grade")]
        public string LowGrade { get; set; }

        public string Name { get; set; }

        [JsonProperty("nces_id")]
        [BsonElement("nces_id")]
        public string NcesId { get; set; }

        public string Phone { get; set; }

        public SISSchoolDataPrincipal Principal { get; set; }

        [JsonProperty("school_number")]
        [BsonElement("school_number")]
        public string SchoolNumber { get; set; }

        [JsonProperty("sis_id")]
        [BsonElement("sis_id")]
        public string SisId { get; set; }

        [JsonProperty("state_id")]
        [BsonElement("state_id")]
        public string StateId { get; set; }

        public string Id { get; set; }
    }

    public class SISSchoolDataLocation
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }

    public class SISSchoolDataPrincipal
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}