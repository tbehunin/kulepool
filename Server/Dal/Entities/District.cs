using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class District
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public SyncState SyncState { get; set; }
    }
}