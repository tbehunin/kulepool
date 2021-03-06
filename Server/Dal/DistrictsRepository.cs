﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Dal
{
    public interface IDistrictsRepository
    {
        void BulkWrite(IList<District> districts);
        void Save(District district);
        IList<District> List(string query = null);
    }
    public class DistrictsRepository : IDistrictsRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<District> _collection;

        public DistrictsRepository(IMongoClient client, string database)
        {
            // todo: move this out to IOC config
            var cp = new ConventionPack();
            cp.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camel case", cp, x => true);

            _client = client;
            _db = _client.GetDatabase(database);
            _collection = _db.GetCollection<District>("districts");
        }

        public void BulkWrite(IList<District> districts)
        {
            throw new NotImplementedException();
        }

        public void Save(District district)
        {
            if (district.Id.Equals(ObjectId.Empty))
            {
                _collection.InsertOne(district);
            }
            else
            {
                _collection.ReplaceOne(x => x.Id == district.Id, district, new UpdateOptions { IsUpsert = true });
            }
        }

        public IList<District> List(string query = null)
        {
            return string.IsNullOrWhiteSpace(query) ? _collection.Find("{}").ToList() : _collection.Find(query).ToList();
        }
    }
}
