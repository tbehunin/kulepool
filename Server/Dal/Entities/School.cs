﻿using Clever.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Entities
{
    public class School
    {
        public ObjectId Id { get; set; }
        
        public string ExternalId { get; set; }

        public bool Volatile { get; set; }

        public bool Active { get; set; }

        public District District { get; set; }

        [BsonElement("sisData")]
        public SISSchool SISData { get; set; }
    }
}