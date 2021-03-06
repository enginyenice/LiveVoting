using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}