using System.ComponentModel.DataAnnotations;
namespace API_Server.DTOs
{
    public class UserSignUpDTOs
    {
       
        [Required(ErrorMessage = "Vui lòng nhập họ và tên!")]
        [StringLength(150, ErrorMessage = "Họ tên không thể chứa quá 150 kí tự.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản!")]
        [RegularExpression("^[a-zA-Z0-9]{4,25}$", ErrorMessage = "Tên tài khoản không chứa kí tự đặt biệt và phải chứa ít nhất 4 kí tự hoặc tối đa 25 kí tự!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email!")]
        [RegularExpression(@"^[\w]{4,15}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Vui lòng nhập đúng định dạng Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [RegularExpression(@"^.{6,20}$", ErrorMessage = "Mật khẩu phải chứa ít nhất 6 kí tự hoặc tối đa 20 kí tự!")]
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
