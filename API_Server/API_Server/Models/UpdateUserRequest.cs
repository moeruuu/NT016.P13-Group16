﻿
namespace API_Server.Models
{
    public class UpdateUserRequest
    {
        //public string ID { get; set; }
        
        public string FullName { get; set; }
        public string Bio {  get; set; }
        public string Avatar {  get; set; }
    }
}
