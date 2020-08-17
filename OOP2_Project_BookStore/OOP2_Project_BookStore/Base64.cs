using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOP2_Project_BookStore
{
    public class Base64
    {
        public static string toBase64(string txt)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(txt);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Tobase64Image(string imagepath)
        {
            byte[] imageArray = File.ReadAllBytes(imagepath);
            return Convert.ToBase64String(imageArray);
        }

        public static string Tobase64Image(Image image)
        {
            byte[] imageArray;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageArray = ms.ToArray();
            }

            return Convert.ToBase64String(imageArray);
        }

        public static Image GetImage(string base64Image)
        {
            byte[] bytes = Convert.FromBase64String(base64Image);
            using (MemoryStream ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
        }
    }
}
