using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Test.Model;
using Test.Service;
using Bitmap = System.Drawing.Bitmap;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;

namespace Test.Controllers.Home
{
    public class HomeController : Controller
    {
        public IService<User> _service { get; }

        public HomeController(IService<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var user = _service.GetAll();
            return View(user);
        }
        public IActionResult Detail(int id)
        {
            var user = _service.GetById(id);
            return View(user);
        }

        public IActionResult Add(User model)
        {
            var user = _service.Add(model);
            return View(user);
        }
        public IActionResult QRCode()
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            string Url = "http://www.baidu.com";
            QRCodeData codeData = generator.CreateQrCode(Url, QRCodeGenerator.ECCLevel.M, true);
            QRCode qrcode = new QRCode(codeData);
            Bitmap qrImage = qrcode.GetGraphic(50, Color.Black, Color.White, true);
            MemoryStream ms = new MemoryStream();
            qrImage.Save(ms, ImageFormat.Bmp);
            Image image = Image.FromStream(ms);
            image.Save(@"F:\qrcode.png");
            byte[] bytes = ms.GetBuffer();
            ms.Dispose();
            return File(bytes, "image/Png");
        }

        public IActionResult Upload()
        {
            return View();
        }
    }
}