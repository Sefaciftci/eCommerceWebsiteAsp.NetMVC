using eCommerce.Entities;
using eCommerce.Models;
using eCommerce.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eCommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;
        public AccountController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }
        [Authorize(Policy = "CustomerPolicy")]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rol = await _serviceRol.GetAsync(r => r.Adi == "Customer");
                    if (rol == null)
                    {
                        ModelState.AddModelError("", "Kayıt başarısız");
                        return View();
                    }
                    kullanici.RolId = rol.Id;   
                    await _service.AddAsync(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata");
                }

            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(CustomerViewModel customerViewModel)
        {
            try
            {
                var account = _service.Get(k => k.Email == customerViewModel.Email && k.Sifre == customerViewModel.Sifre);
                if (account == null)
                {

                    ModelState.AddModelError("", "Giriş Başarısız");
                }
                else
                {
                    var rol = await _serviceRol.GetAsync(rol => rol.Id == account.RolId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, account.Adi),
                        new Claim("Role","Admin")
                    };
                    if (rol is not null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role , rol.Adi));

                    }
                    var useIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useIdentity);
                    await HttpContext.SignInAsync(principal);
                    if (rol.Adi == "Admin")
                    {
                        return Redirect("/Admin");
                    }
                    return Redirect("/Account");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu");
            } 
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
