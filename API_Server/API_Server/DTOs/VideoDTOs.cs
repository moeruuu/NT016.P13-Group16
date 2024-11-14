using System.ComponentModel.DataAnnotations;

namespace API_Server.DTOs
{
    public class UploadVideoDTOs
    {

        [Required(ErrorMessage = "Vui lòng nhập tên phim")]
        [StringLength(100, ErrorMessage = "Tên phim không thể chứa quá 100 kí tự.")]
        public string Title { get; set; }
        [StringLength(250, ErrorMessage = "Giới thiệu không thể chứa quá 250 kí tự.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ảnh xem trước cho video!")]
        //[Url(ErrorMessage = "Đường dẫn ảnh không hợp lệ.")]
        public IFormFile UrlImage { get; set; }
        //[Url(ErrorMessage = "Đường dẫn video không hợp lệ.")]
        [Required(ErrorMessage = "Vui lòng chọn video để update.")]
        public IFormFile UrlVideo { get; set; }
        public long Size { get; set; }

    }
}
