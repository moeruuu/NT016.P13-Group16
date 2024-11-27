namespace API_Server.Data
{
    public class VideoStatus
    {
        public string VideoID { get; set; }
        public bool IsPlaying { get; set; }
        public double Progress { get; set; }
    }
}
