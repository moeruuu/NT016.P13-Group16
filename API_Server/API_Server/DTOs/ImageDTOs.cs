using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API_Server.DTOs
{
    public class ImageDTOs
    {
        [Required(ErrorMessage = "Vui lòng chọn ảnh!")]

        public IFormFile file { get; set; }
        /*public int type { get; set; } //0=avatar, 1 = ảnh video
        public string OwnerID { get; set; }*/

    }
}
