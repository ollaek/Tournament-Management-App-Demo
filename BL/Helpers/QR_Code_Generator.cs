using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using QRCoder;

namespace BL.Helpers
{
    public class QR_Code_Generator
    {
        public string Generate_QRCode(string tag)
        {
            string outputData = WebConfigurationManager.AppSettings["TournamentsQRCodeLink"];

            string outputPath = WebConfigurationManager.AppSettings["TournamentsImagesPath"];
            string codePath = outputPath + "Tag_" + tag + ".png";
            Bitmap logo = new Bitmap(@"D:\whatsapp-png-logo-1.png");

            PayloadGenerator.Url generator = new PayloadGenerator.Url(outputData + tag);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(generator, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, logo ,15);
            SaveByteArrayAsImage(codePath, qrCodeImage);
            return codePath;
        }

        private void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
           
            byte[] bytesArr = Convert.FromBase64String(base64String);
            ImageConverter imageConverter = new System.Drawing.ImageConverter();
            System.Drawing.Image imagee = imageConverter.ConvertFrom(bytesArr) as System.Drawing.Image;
            Stream memstr = new MemoryStream(bytesArr);
            image = System.Drawing.Image.FromStream(memstr);
            image.Save(fullOutputPath, ImageFormat.Png);
            memstr?.Dispose();
        }


    }
}
