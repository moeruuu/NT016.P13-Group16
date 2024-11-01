using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API_Server.Data
{
    public class User
    {
        [BsonId]
        public ObjectId UserId { get; set; }
        [BsonElement("Fullname")]
        public string Fullname { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }
        [BsonElement("Profilepicture")]
        public string Profilepicture;

        [BsonElement("Token")]
        public string Token { get; set; }
    }
}