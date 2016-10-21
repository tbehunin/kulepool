using Common;
using MongoDB.Bson;

namespace Dal.Entities
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public District District { get; set; }
        public School School { get; set; }
        public SISStudent SISData { get; set; }
    }
}
