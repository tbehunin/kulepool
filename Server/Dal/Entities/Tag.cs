using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    [BsonIgnoreExtraElements]
    public class Tag
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}