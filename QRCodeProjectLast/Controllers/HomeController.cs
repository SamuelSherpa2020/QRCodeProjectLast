using QRCodeProjectLast.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCodeProjectLast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQRCode(QRCodeModel qrCode)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCodeimage = new QRCode(qrCodeData);
            Bitmap qrBitMap = qrCodeimage.GetGraphic(60);
            byte[] BitmapArray = qrBitMap.BitmapToByteArray();
            string QrUri = string.Format("data:image/png;base64,{0}",Convert.ToBase64String(BitmapArray));

            ViewBag.QrCodeUri = QrUri;
            return View();
        }
    }

    // Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            // Using statement ensures proper disposal of resources, like MemoryStream
            using (MemoryStream ms = new MemoryStream())
            {
                // Save the Bitmap to the MemoryStream in PNG format
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}