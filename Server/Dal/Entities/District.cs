using Common;
using MongoDB.Bson;

namespace Dal.Entities
{
    public class District
    {
        public ObjectId Id { get; set; }
        public SyncState SyncState { get; set; }
        public SISDistrict SISData { get; set; }
    }
}