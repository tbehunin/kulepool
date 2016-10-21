using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Dal
{
    public interface ISchoolsRepository
    {
        void BulkSave(IList<School> schools);
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

        public void BulkSave(IList<School> schools)
        {
            var records = schools.Select(x => x.Id.Equals(ObjectId.Empty) ?
                (WriteModel<School>)new InsertOneModel<School>(x) :
                new ReplaceOneModel<School>(Builders<School>.Filter.Eq("_id", x.Id), x)).ToList();
            _collection.BulkWrite(records);
        }

        public IList<School> List(string query)
        {
            return string.IsNullOrWhiteSpace(query) ? _collection.Find("{}").ToList() : _collection.Find(query).ToList();
        }
    }
}
