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
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Role")]
        //0 là Admin, 1 là User
        public int Role { get; set; } 
        [BsonElement("Profilepicture")]
        public string Profilepicture { get; set; }
        [BsonElement("Bio")]
        public string Bio {  get; set; }
        [BsonElement("IsOnline")]
        public bool IsOnline { get; set; }

    }
}