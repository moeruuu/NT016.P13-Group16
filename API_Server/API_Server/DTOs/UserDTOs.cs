using System.ComponentModel.DataAnnotations;
namespace API_Server.DTOs
{
    public class UserSignUpDTOs
    {
        [Required(ErrorMessage = "Fullname is required.")]
        [StringLength(150, ErrorMessage = "Fullname can't exceed 100 characters.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression("^a-zA-Z0-9{25}$", ErrorMessage = "Username can't use exceed 25 characters.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, ErrorMessage = "Fullname can't exceed 20 characters.")]
        public string Password { get; set; }

    }

    public class UserLogInDTOs 
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

    public class UserUpdateInformationDTOs
    {
        [StringLength(150, ErrorMessage = "Fullname can't exceed 100 characters.")]
        public string Fullname { get; set; }
        [Url(ErrorMessage = "Profile picture must be a valid URL.")]
        public string ProfilePicture { get; set; }
    }

}
