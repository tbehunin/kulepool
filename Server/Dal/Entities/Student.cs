using Clever.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class Student
    {
        public ObjectId Id { get; set; }

        public string ExternalId { get; set; }

        public District District { get; set; }

        public School School { get; set; }

        [BsonElement("sisData")]
        public SISStudent SISData { get; set; }
    }
}
