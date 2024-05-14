using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ClanSystem.Server.Entities
{
    public class ClanUserRelation
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = string.Empty;

        [BsonElement("User"), BsonRepresentation(BsonType.String)]
        public string? User { get; set; }

        [BsonElement("UserContribution"), BsonRepresentation(BsonType.Int32)]
        public int? UserContribution { get; set; }

        [BsonElement("ClanName"), BsonRepresentation(BsonType.String)]
        public string? ClanName { get; set; }
    }
}
