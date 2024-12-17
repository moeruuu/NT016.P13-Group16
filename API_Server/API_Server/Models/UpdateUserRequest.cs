
namespace API_Server.Models
{
    public class UpdateUserRequest
    {
        public string FullName { get; set; }
        public string Bio {  get; set; }
        public IFormFile Avatar {  get; set; }
    }
}
