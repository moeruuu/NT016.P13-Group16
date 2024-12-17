using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
namespace API_Server.DTOs
{
    public class UserSignUpDTOs
    {
        [Required(ErrorMessage = "Please enter your full name!")]
        [StringLength(150, ErrorMessage = "Full name cannot exceed 150 characters.")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Please enter a username!")]
        [RegularExpression("^[a-zA-Z0-9]{4,25}$", ErrorMessage = "Username cannot contain special characters and must be at least 4 characters or at most 25 characters long!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter an email!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        [RegularExpression(@"^.{6,20}$", ErrorMessage = "Password must be at least 6 characters or at most 20 characters long!")]
        public string Password { get; set; }
    }

    public class UserLogInDTOs 
    {
        [Required(ErrorMessage = "Please enter a username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        public string Password { get; set; }
    }

    public class LogOutDTOs
    {
        [Required(ErrorMessage = "UserID does not exist")]
        public string Id { get; set; }
    }

    public class ForgetPassDTOs
    {
        [Required(ErrorMessage = "Request is unclear!")]
        public int statusCode { get; set; } // 0 là chưa gửi, 1 là đúng OTP, 2 là sai OTP

        [Required(ErrorMessage = "Please enter the registered email!")]
        [RegularExpression(@"^[\w]{4,30}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        [RegularExpression(@"^.{6,20}$", ErrorMessage = "Password must be at least 6 characters or at most 20 characters long!")]
        public string Password { get; set; }
    }
    
}
