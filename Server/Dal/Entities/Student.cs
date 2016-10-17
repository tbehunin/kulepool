using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        public string Id { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("grade")]
        public Grade Grade { get; set; }
        [BsonElement("school")]
        public School School { get; set; }
        [BsonElement("tags")]
        public List<Tag> Tags { get; set; }
        [BsonElement("assignedRoutes")]
        public List<Route> AssignedRoutes { get; set; }
    }
}
