using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API_Server.DTOs
{
    public class ImageDTOs
    {
        [Required(ErrorMessage = "Please select an image!")]
        public IFormFile file { get; set; }

    }
}
