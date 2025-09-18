using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;

namespace CommercialAutomation.Controllers
{
    public class QrController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator createcode= new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = createcode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = karekod.GetGraphic(10))
                {
                    image.Save(ms,ImageFormat.Png);
                    ViewBag.karekodimage="data:/image/png;base64,"+Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}