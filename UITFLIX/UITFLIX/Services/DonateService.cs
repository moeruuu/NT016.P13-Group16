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
                //Đổi hình ảnh sang chuỗi byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);

                string mimeType = GetMimeType(format);

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

