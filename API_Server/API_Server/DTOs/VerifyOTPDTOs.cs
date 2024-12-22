using API_Server.Data;
namespace API_Server.DTOs
{
    public class VerifyOTPDTOs
    {
        public int requestCode { get; set; }    //0 là OTP đăng ký mail, 1 là OTP quên mật khẩu
        public string OTP { get; set; }
        public string Email { get; set; }
    }

    public class TempUserData
    {
        public User User { get; set; }
        public string OTP { get; set; }
        public DateTime Expiration { get; set; }
    }
}
