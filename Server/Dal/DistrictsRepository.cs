﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using MongoDB.Driver;

namespace Dal
{
    public interface IDistrictsRepository
    {
        void BulkWrite(IList<District> districts);
        IList<District> List(string query = null);
    }
    public class DistrictsRepository : IDistrictsRepository
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<District> _collection;

        public DistrictsRepository()
        {
            _client = new MongoClient();
            _db = _client.GetDatabase("kulepool");
            _collection = _db.GetCollection<District>("districts");
        }

        public void BulkWrite(IList<District> districts)
        {
            throw new NotImplementedException();
        }

        public IList<District> List(string query)
        {
            throw new NotImplementedException();
        }
    }
}
