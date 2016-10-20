using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public School School { get; set; }
        public SISStudent SISStudentData { get; set; }
    }
}
