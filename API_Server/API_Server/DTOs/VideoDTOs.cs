using System.ComponentModel.DataAnnotations;

namespace API_Server.DTOs
{
    public class UploadVideoDTOs
    {

        [Required(ErrorMessage = "Please enter the movie title.")]
        [StringLength(100, ErrorMessage = "The movie title cannot exceed 100 characters.")]
        public string Title { get; set; }
        [StringLength(1000, ErrorMessage = "The description cannot exceed 250 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select a preview image for the video.")]
        public IFormFile UrlImage { get; set; }
        [Required(ErrorMessage = "Please select a video to update.")]
        public IFormFile UrlVideo { get; set; }
        [Required(ErrorMessage = "Please select a genre.")]
        public string Tag { get; set; }

    }
}
