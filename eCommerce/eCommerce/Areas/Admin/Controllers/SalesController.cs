using eCommerce.Entities;
using eCommerce.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerce.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SalesController : Controller
    {
        private readonly IService<Satis> _service;
        private readonly IService<Urun> _serviceUrun;
        private readonly IService<Musteri> _serviceMusteri;

        public SalesController(IService<Satis> service, IService<Urun> serviceUrun, IService<Musteri> serviceMusteri)
        {
            _service = service;
            _serviceUrun = serviceUrun;
            _serviceMusteri = serviceMusteri;
        }

        // GET: SalesController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Satis satis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(satis);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
            return View(satis);
        }

        // GET: SalesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Satis satis)
        {
            try
            {
                _service.Update(satis);
                await _service.SaveAsync();
                return RedirectToAction(nameof(System.Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu");
            }
            ViewBag.AracId = new SelectList(await _serviceUrun.GetAllAsync(), "Id", "Formu");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // GET: SalesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Satis satis)
        {
            try
            {
                _service.Delete(satis);
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
