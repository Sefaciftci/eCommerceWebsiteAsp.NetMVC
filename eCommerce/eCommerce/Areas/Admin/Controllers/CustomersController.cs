using eCommerce.Entities;
using eCommerce.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerce.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class CustomersController : Controller
    {
        private readonly IService<Musteri> _service;
        private readonly IService<Urun> _serviceUrun;
        public CustomersController(IService<Musteri> service, IService<Urun> serviceUrun)
        {
            _service = service;
            _serviceUrun = serviceUrun;
        }

        // GET: CustomersController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(musteri);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            return View(musteri);
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Musteri musteri)
        {
            try
            {
                _service.Update(musteri);
                await _service.SaveAsync();
                return RedirectToAction(nameof(System.Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu");
            }
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            return View();
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Musteri musteri)
        {
            try
            {
                _service.Delete(musteri);
                await _service.SaveAsync();
                return RedirectToAction(nameof(System.Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
