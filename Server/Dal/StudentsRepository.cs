using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;
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
            _db = _client.GetDatabase("kulepool");
            _collection = _db.GetCollection<Student>("studentstodd");
        }

        public Student Get(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Student> List(string query)
        {
            return string.IsNullOrWhiteSpace(query) ? _collection.Find("{}").ToList() : _collection.Find(query).ToList();
        }
    }
}
