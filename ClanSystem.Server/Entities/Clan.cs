using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ClanSystem.Server.Entities
{
    public class Clan
    {

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = string.Empty;

        [BsonElement("clanName"), BsonRepresentation(BsonType.String)]
        public string? ClanName { get; set; }

        [BsonElement("points"), BsonRepresentation(BsonType.Int32)]
        public int? Points { get; set; }

        [BsonElement("userCount"), BsonRepresentation(BsonType.Int32)]
        public int? UserCount { get; set; }
    }
}
