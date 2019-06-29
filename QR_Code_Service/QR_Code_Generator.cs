using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using QRCoder;

namespace QR_Code_Service
{
    public class QR_Code_Generator
    {
        public string Generate_QRCode(string tag)
        {
            string outputPath = WebConfigurationManager.AppSettings["TournamentsImagesPath"];
            string codePath = outputPath + "Code_#" + tag;

            Url generator = new Url("http://localhost:53792/api/tournaments/getbytag?tag="+tag);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.H);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("D:\\logo.png"),15);
            SaveByteArrayAsImage(codePath, qrCodeImage);
            return codePath;
        }

        private void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Png);
        }


    }
}
