using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    [BsonIgnoreExtraElements]
    public class Route
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}