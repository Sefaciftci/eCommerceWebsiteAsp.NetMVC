using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")] //bu controller bir admin area sı  içerisinde çalışıcak
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
