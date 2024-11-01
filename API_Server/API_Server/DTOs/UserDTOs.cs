using System.ComponentModel.DataAnnotations;
namespace API_Server.DTOs
{
    public class UserSignUpDTOs
    {
       
        [Required(ErrorMessage = "Vui lòng nhập họ và tên!")]
        [StringLength(150, ErrorMessage = "Họ tên không thể chứa quá 150 kí tự.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản!")]
        [RegularExpression("^a-zA-Z0-9{25}$", ErrorMessage = "Tên tài khoản không thể chứa quá 25 kí tự.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [StringLength(20, ErrorMessage = "Mặt khẩu không thể chứa quá 20 kí tự.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu!")]
        public string ConfirmPassword { get; set; }

    }

    public class UserLogInDTOs 
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get; set; }
    }

    public class ForgetPassDTOs
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu!")]
        public string ConfirmPassword { get; set;}

    }



}
