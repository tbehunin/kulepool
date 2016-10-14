using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepo.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dal
{
    public interface IStudentsRepository
    {
        Student Get(string id);
        IList<Student> List(string query);
    }

    public class StudentsRepository : IStudentsRepository
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Student> _collection;

        public StudentsRepository()
        {
            _client = new MongoClient();
            _db = _client.GetDatabase("kulepule");
            var collection = _db.GetCollection<Student>("students");
        }

        public Student Get(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Student> List(string query)
        {
            return _collection.Find(query).ToList();
        }
    }
}
