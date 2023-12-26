using eCommerce.Entities;
using eCommerce.Service.Abstract;
using eCommerce.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerce.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy ="UserPolicy")]
    public class ProductsController : Controller
    {
        private readonly IService<Urun> _service;
        private readonly IService<Marka> _serviceMarka;

        public ProductsController(IService<Urun> service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }

        // GET: ProductsController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(),"Id","Adi");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Urun? urun)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    await _service.AddAsync(urun);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(urun);
        }

        // GET: ProductsController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Urun urun)
        {
            if (ModelState.IsValid)
            {
                try
                {                  
                    _service.Update(urun);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(System.Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            }            
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(urun);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Urun urun)
        {
            try
            {
                _service.Delete(urun);
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
