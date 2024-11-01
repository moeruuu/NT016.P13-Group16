﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Models
{
    public class TokenData
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("RefreshToken")]
        public string RefreshToken { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonElement("ExpiryTime")]
        public DateTime ExpiryTime { get; set; }
        [BsonElement("UsedToken")]
        public int UsedToken { get; set; }
    }
}
