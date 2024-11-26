using System.ComponentModel.DataAnnotations;
namespace API_Server.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ!")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới!")]
        [RegularExpression(@"^.{6,20}$", ErrorMessage = "Mật khẩu phải chứa ít nhất 6 kí tự hoặc tối đa 20 kí tự!")]
        public string NewPassword { get; set; }
    }
}
