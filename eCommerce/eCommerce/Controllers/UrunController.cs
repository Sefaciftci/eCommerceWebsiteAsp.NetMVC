using eCommerce.Entities;
using eCommerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class UrunController : Controller
    {

        private readonly IService<Urun> _serviceUrun;

        public UrunController(IService<Urun> serviceUrun)
        {
            _serviceUrun = serviceUrun;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _serviceUrun.FindAsync(id);
            return View(model);
        }
    }
}
