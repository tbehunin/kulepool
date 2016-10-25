using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clever.Entities;
using Dal.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Dal
{
    public interface ISchoolsRepository
    {
        void SyncSchools(District district, IList<SISSchool> sisSchools);
        IList<School> List(string query = null);
    }
    public class SchoolsRepository : ISchoolsRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<School> _collection;

        public SchoolsRepository(IMongoClient client, string database)
        {
            _client = client;
            _db = _client.GetDatabase(database);
            _collection = _db.GetCollection<School>("schools");
        }

        public void SyncSchools(District district, IList<SISSchool> sisSchools)
        {
            var filter = Builders<School>.Filter;
            var update = Builders<School>.Update;

            // First mark all schools in the district as volatile
            _collection.UpdateMany(
                filter.Eq(x => x.District.Id, district.Id),
                update.Set(x => x.Volatile, true));

            // Now update all schools accordingly
            var models = new List<UpdateOneModel<School>>();
            foreach (var sisSchool in sisSchools)
            {
                var model = new UpdateOneModel<School>(
                    filter.Eq(school => school.ExternalId, sisSchool.Data.Id),
                    update
                        .Set(school => school.Active, true)
                        .Set(school => school.District, district)
                        .Set(school => school.ExternalId, sisSchool.Data.Id)
                        .Set(school => school.SISData, sisSchool)
                        .Set(school => school.Volatile, false));
                model.IsUpsert = true;
                models.Add(model);
            }
            _collection.BulkWrite(models);

            // Lastly inactivate any old schools
            _collection.UpdateMany(
                filter.Eq(x => x.District.Id, district.Id) & filter.Eq(x => x.Volatile, true),
                update.Set(x => x.Volatile, false));
        }

        public IList<School> List(string query)
        {
            return string.IsNullOrWhiteSpace(query) ? _collection.Find("{}").ToList() : _collection.Find(query).ToList();
        }
    }
}
