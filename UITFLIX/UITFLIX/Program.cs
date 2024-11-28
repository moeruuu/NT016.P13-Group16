using System.Drawing.Text;
using UITFLIX.Services;

namespace UITFLIX
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LogIn());
            /*string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJmYTg3N2U2Mi1jZTAxLTQ4ZjItOGM3OS0wZjE3YTU1ZGJhNWUiLCJzdWIiOiI2NzMzN2YxYmM1Mjk3Yjc5ODQ5NmNlZDkiLCJ1bmlxdWVfbmFtZSI6InV5bnRoeWVlIiwiZW1haWwiOiJ0aHlpemRhYmV6dEBnbWFpbC5jb20iLCJuYW1lIjoiVXnDqm4gVGh5eSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTczMjc4MTI1OCwiZXhwIjoxNzMyNzg4NDU4LCJpYXQiOjE3MzI3ODEyNTgsImlzcyI6IlVJVEZMSVgiLCJhdWQiOiJVSVRGTElYX0NMSUVOVCJ9.fLM-evdU_UebeunuRbiQVQHFrCukApmNGt_8NV6iEVk";
            VideoService service = new VideoService();*/
            //Application.Run(new Room(token, service));
        }
    }
}