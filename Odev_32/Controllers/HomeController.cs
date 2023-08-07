using Microsoft.AspNetCore.Mvc;
using Odev_32.Models;
using System;
using System.Diagnostics;

namespace Odev_32.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["Sayi"] = 9;
            return RedirectToAction("Index2");
        }

        public IActionResult Index2()   // Ana sayfa 0 Home a basınca 9 yazıyor ???
        {
            // TempData'den gelen değeri alın
            int gelenSayi = Convert.ToInt32(TempData["Sayi"]);

            // Ekranda 0 değeri görünmesinin nedeni, TempData'nin içeriğinin bir seferlik kullanıldıktan sonra otomatik olarak temizlenmesidir. Bu nedenle, TempData üzerinden gönderilen değerler bir sonraki HTTP isteğinde kullanılamazlar.

            // Yani, TempData ile bir veriyi bir action'dan diğerine taşımak için, bu veriyi alıcı action'da almanız ve daha sonra tekrar göndermeniz gereklidir. TempData bir veriye tek seferlik erişimi sağlar, bu nedenle ikinci HTTP isteğinde değeri almadığınız için 0 değeri görünüyor.

            // Çözüm olarak, Index2 action'ında TempData'den gelen değeri almanız gerekir.Bu şekilde, Index action'ında TempData'ye attığınız değeri Index2 action'ında kullanabilir

            // View'e gelen değeri gönderin
            return View(gelenSayi);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Bowling()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}