using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.DTOs
{
    public class UserJoinedDTOs
    {
        public string roomid { get; set; }
    }

    public class AddVideoDTOs
    {
        public string roomid { get; set;}
        public string videoid { get; set;}
    }
}
