using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JournalControlWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using JournalControlWebApp.Models.ViewModel;
using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SignInManager<Worker> _signInManager;

        private readonly UserManager<Worker> _userManager;

        private readonly journalContext db;

        public HomeController(ILogger<HomeController> logger, UserManager<Worker> userManager, SignInManager<Worker> signInManager, journalContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            db = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "TRUE";
            }
            else
            {
                ViewBag.Message = "FALSE";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel() { ReturnURL = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    Worker currentWorker = await _userManager.FindByNameAsync(model.Login);
                    if (currentWorker != null && currentWorker.IsFirstLogin)
                    {
                        return RedirectToAction("SetPassword", "Home", (object)model.ReturnURL);
                    }
                    if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                        return Redirect(model.ReturnURL);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправльный логин или пароль!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword(string returnUrl = null)
        {
            Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);

            if (currentWorker != null)
            {
                ChangePasswordViewModel model = new ChangePasswordViewModel { Id = currentWorker.Id.ToString(), Login = User.Identity.Name, ReturnURL = returnUrl };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SetPassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Worker worker = await _userManager.FindByIdAsync(model.Id);
                if (worker != null)
                {
                    var _passwordValidator = HttpContext.RequestServices.GetService(typeof(IPasswordValidator<Worker>)) as IPasswordValidator<Worker>;
                    var _passwordHasher = HttpContext.RequestServices.GetService(typeof(IPasswordHasher<Worker>)) as IPasswordHasher<Worker>;

                    IdentityResult result = await _passwordValidator.ValidateAsync(_userManager, worker, model.NewPassword);

                    if (result.Succeeded)
                    {
                        worker.PasswordHash = _passwordHasher.HashPassword(worker, model.NewPassword);
                        worker.IsFirstLogin = false;
                        await _userManager.UpdateAsync(worker);
                        if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                            return Redirect(model.ReturnURL);
                        else
                            return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь не найден");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
