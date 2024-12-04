using System.Text.RegularExpressions;

namespace API_Server.Models
{
    public class EmailRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string? AttachmentPath { get; set; }
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Email) && IsValidEmail(Email) &&
                   !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(Subject) &&
                   !string.IsNullOrEmpty(Body);
        }

        public bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

    }

}
