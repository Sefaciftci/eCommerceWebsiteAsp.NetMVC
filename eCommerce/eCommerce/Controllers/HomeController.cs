using eCommerce.Entities;
using eCommerce.Models;
using eCommerce.Service.Abstract;
using eCommerce.Service.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Urun> _serviceUrun;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IService<Urun> serviceUrun)
        {
            _logger = logger;
            _serviceUrun = serviceUrun;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var model = new HomePageViewModel()
            {
                Urunler = await _serviceUrun.GetAllAsync()
            };
            return View(model);
        }
              
   
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
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