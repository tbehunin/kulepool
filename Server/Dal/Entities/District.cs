using Clever.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class District
    {
        public ObjectId Id { get; set; }

        public SyncState SyncState { get; set; }

        [BsonElement("sisData")]
        public SISDistrict SISData { get; set; }
    }
}