using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using MongoDB.Driver;

namespace Dal
{
    public interface ISchoolsRepository
    {
        void BulkWrite(IList<School> schools);
        IList<School> List(string query = null);
    }
    public class SchoolsRepository : ISchoolsRepository
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<School> _collection;

        public SchoolsRepository()
        {
            _client = new MongoClient();
            _db = _client.GetDatabase("kulepool");
            _collection = _db.GetCollection<School>("schools");
        }

        public void BulkWrite(IList<School> schools)
        {
            throw new NotImplementedException();
        }

        public IList<School> List(string query)
        {
            throw new NotImplementedException();
        }
    }
}
