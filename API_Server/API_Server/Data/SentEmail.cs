using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace API_Server.Data
{
    public class SentEmail
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("senderEmail")]
        public string SenderEmail { get; set; }
        [BsonElement("recipientEmail")]
        public string RecipientEmail { get; set; }

        [BsonElement("subject")]
        public string Subject { get; set; }

        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("sentAt")]
        public DateTime SentAt { get; set; }
    }
}
