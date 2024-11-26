namespace API_Server.DTOs
{
    public class VerifyOTPDTOs
    {
        //0 là OTP đăng ký mail, 1 là OTP quên mật khẩu
        public int requestCode { get; set; }
        public string OTP { get; set; }
    }
}
