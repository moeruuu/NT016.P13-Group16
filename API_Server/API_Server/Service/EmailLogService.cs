using MongoDB.Driver;
using API_Server.Data;
using Microsoft.Extensions.Configuration;
using API_Server.DTOs;
using MongoDB.Bson;
using System.Net.WebSockets;
namespace API_Server.Service
{
    public class EmailLogService
    {
        private readonly IMongoCollection<SentEmail> sentEmails;

        public EmailLogService(IMongoDatabase database)
        {
            sentEmails = database.GetCollection<SentEmail>("SentEmails");
            var indexKeys = Builders<SentEmail>.IndexKeys.Ascending(e => e.SenderEmail);
            var indexOptions = new CreateIndexOptions { Unique = false };
            var indexModel = new CreateIndexModel<SentEmail>(indexKeys, indexOptions);

            sentEmails.Indexes.CreateOne(indexModel);
        }


        public async Task LogSentEmail(SentEmail sentEmail)
        {
            if (sentEmail == null)
                throw new ArgumentNullException(nameof(sentEmail), "Email đã gửi không được trống");

            sentEmail.SentAt = DateTime.UtcNow;

            try
            {
                await sentEmails.InsertOneAsync(sentEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi lại email đã gửi: {ex.Message}");
                throw;
            }
        }

        public async Task<List<SentEmail>> GetSentEmailsBySender(string senderEmail)
        {
            if (string.IsNullOrEmpty(senderEmail))
                throw new ArgumentException("Người gửi không được trống.", nameof(senderEmail));

            try
            {
                return await sentEmails.Find(email => email.SenderEmail == senderEmail)
                                        .SortByDescending(email => email.SentAt)
                                        .Limit(100)
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                throw;
            }
        }


    }

}
