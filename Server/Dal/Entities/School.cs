using Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class School
    {
        public ObjectId Id { get; set; }
        public District District { get; set; }
        public SISSchool SISData { get; set; }
    }
}