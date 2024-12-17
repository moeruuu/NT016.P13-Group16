using System.ComponentModel.DataAnnotations;
namespace API_Server.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Please enter the old password!")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Please enter the new password!")]
        [RegularExpression(@"^.{6,20}$", ErrorMessage = "The password must be at least 6 characters and no more than 20 characters long!")]
        public string NewPassword { get; set; }
    }
}
