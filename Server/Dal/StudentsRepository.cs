using System;
using System.Collections.Generic;
using System.Linq;
using Clever.Entities;
using Dal.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dal
{
    public interface IStudentsRepository
    {
        Student Get(string id);
        IList<Student> List(string query);
        void SyncStudents(District district, School school, IList<SISStudent> students);
    }

    public class StudentsRepository : IStudentsRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Student> _collection;

        public StudentsRepository(IMongoClient client, string database)
        {
            _client = client;
            _db = _client.GetDatabase(database);
            _collection = _db.GetCollection<Student>("students");
        }

        public Student Get(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Student> List(string query)
        {
            return string.IsNullOrWhiteSpace(query) ? _collection.Find("{}").ToList() : _collection.Find(query).ToList();
        }

        public void SyncStudents(District district, School school, IList<SISStudent> sisStudents)
        {
            var filter = Builders<Student>.Filter;
            var update = Builders<Student>.Update;

            // First mark all students in the school as volatile
            _collection.UpdateMany(
                filter.Eq(x => x.School.Id, school.Id),
                update.Set(x => x.Volatile, true));

            // Now update all students accordingly
            var models = new List<UpdateOneModel<Student>>();
            foreach (var sisStudent in sisStudents)
            {
                var model = new UpdateOneModel<Student>(
                    filter.Eq(student => student.ExternalId, sisStudent.Data.Id),
                    update
                        .Set(student => student.Active, true)
                        .Set(student => student.District, district)
                        .Set(student => student.ExternalId, sisStudent.Data.Id)
                        .Set(student => student.School, school)
                        .Set(student => student.SISData, sisStudent)
                        .Set(student => student.Volatile, false));
                model.IsUpsert = true;
                models.Add(model);
            }
            _collection.BulkWrite(models);

            // Lastly inactivate any old schools
            _collection.UpdateMany(
                filter.Eq(x => x.School.Id, school.Id) & filter.Eq(x => x.Volatile, true),
                update
                    .Set(x => x.Active, false)
                    .Set(x => x.Volatile, false));
        }
    }
}
