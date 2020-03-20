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
    /*[Authorize(Roles = "ADMIN")]*/
    public class UsersController : Controller
    {
        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;
        private readonly journalContext db;

        public UsersController(UserManager<Worker> userManager, SignInManager<Worker> signInManager, journalContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = context;
        }

        public IActionResult Index()
        {
            List<Worker> workers = _userManager.Users.ToList();
            foreach (var worker in workers)
            {
                db.Entry(worker).Reference(w => w.Sector).Load();
                db.Entry(worker.Sector).Reference(s => s.Subunit).Load();
            }
            return View(workers);
        }

        [HttpGet]
        public IActionResult CreateUser() => View(new CreateUserViewModel(db));

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Worker worker = new Worker { UserName = model.Login, Family = model.Family, Name = model.Name, Otch = model.Otch, Post = model.Post, SectorId = model.Sector, IsFirstLogin = true };
                var result =
                    await _userManager.CreateAsync(worker, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var er in result.Errors)
                        ModelState.AddModelError(string.Empty, er.Description);
            }
            model.FillLists(db);
            return View(model);
        }
    }
}