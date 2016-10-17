using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    [BsonIgnoreExtraElements]
    public class Grade
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("id")]
        public string IdTest { get; set; }
    }
}