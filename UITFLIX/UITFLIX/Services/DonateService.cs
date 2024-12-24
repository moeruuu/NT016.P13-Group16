//using Newtonsoft.Json;
//using System.Text;
//using UITFLIX.Models;

//namespace UITFLIX.Services
//{
//    public class DonateService
//    {
//        private readonly string _accessToken;

//        public static readonly HttpClient httpClient = new HttpClient
//        {
//            BaseAddress = new Uri("https://localhost:7292/"),
//            Timeout = TimeSpan.FromSeconds(60)
//        };

//        public DonateService(string accessToken)
//        {
//            _accessToken = accessToken;
//            httpClient.DefaultRequestHeaders.Authorization =
//                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
//        }

//        public async Task<DonateResponse?> GenerateQRCodeAsync(DonateRequest request)
//        {
//            var json = JsonConvert.SerializeObject(request);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");
//            var response = await httpClient.PostAsync("/api/Donate/GenerateQRCode", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseContent = await response.Content.ReadAsStringAsync();
//                return JsonConvert.DeserializeObject<DonateResponse>(responseContent);
//            }
//            else
//            {
//                throw new Exception($"Error generating QR Code: {response.ReasonPhrase}");
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITFLIX.Models;

namespace UITFLIX.Services
{
    public class DonateService
    {
        public DonateService(DonateRequest donateRequest)
        {

        }
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 string
                string base64String = Convert.ToBase64String(imageBytes);

                // Get the appropriate MIME type
                string mimeType = GetMimeType(format);

                // Return the Base64 string with the MIME type prefix
                return $"data:{mimeType};base64,{base64String}";
            }
        }

        private static string GetMimeType(ImageFormat format)
        {
            if (format.Equals(ImageFormat.Jpeg))
            {
                return "image/jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                return "image/png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                return "image/bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                return "image/gif";
            }
            else if (format.Equals(ImageFormat.Tiff))
            {
                return "image/tiff";
            }
            else
            {
                throw new ArgumentOutOfRangeException("Unknown image format");
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

    }
}

