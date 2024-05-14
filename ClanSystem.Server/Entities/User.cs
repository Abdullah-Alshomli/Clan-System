using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ClanSystem.Server.Entities
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = string.Empty;

        [BsonElement("Username"), BsonRepresentation(BsonType.String)]
        public string? Username { get; set; }

    }
}
