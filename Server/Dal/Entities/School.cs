using Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class School
    {
        public ObjectId Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public District District { get; set; }
        public GradeLevel HighGrade { get; set; }
        public GradeLevel LowGrade { get; set; }
        public PhysicalLocation Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}