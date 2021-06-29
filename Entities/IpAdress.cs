using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities
{
    public class IpAdress
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Adress { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId { get; set; }
    }
}