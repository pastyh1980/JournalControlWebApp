using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using JournalControlWebApp.Models.ViewModel;
using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class UsersController : Controller
    {
        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;

        public UsersController(UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult CreateUser() => View();

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Worker worker = new Worker { UserName = model.Login, Family = model.Family, Name = model.Name, Otch = model.Otch, Post = model.Post };
                var result =
                    await _userManager.CreateAsync(worker, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var er in result.Errors)
                        ModelState.AddModelError(string.Empty, er.Description);
            }
            return View(model);
        }
    }
}