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
        private readonly RoleManager<Role> _roleManager;
        private readonly journalContext db;

        public UsersController(UserManager<Worker> userManager, SignInManager<Worker> signInManager, RoleManager<Role> roleManager, journalContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
        public IActionResult CreateUser()
        {
            CreateUserViewModel model = new CreateUserViewModel(db);
            model.AllRoles = _roleManager.Roles.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                Worker worker = new Worker { UserName = model.Login, Family = model.Family, Name = model.Name, Otch = model.Otch, Post = model.Post, SectorId = model.Sector, IsFirstLogin = true };
                var result =
                    await _userManager.CreateAsync(worker, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(worker, roles);
                    return RedirectToAction("Index");
                }
                else
                    foreach (var er in result.Errors)
                        ModelState.AddModelError(string.Empty, er.Description);
            }
            model.FillLists(db);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            Worker worker = await _userManager.FindByIdAsync(id);
            if (worker == null)
                return NotFound();

            db.Entry(worker).Reference(w => w.Sector).Load();
            db.Entry(worker.Sector).Reference(s => s.Subunit).Load();

            EditUserViewModel model = new EditUserViewModel(db)
            {
                Id = id,
                Login = worker.UserName,
                Family = worker.Family,
                Name = worker.Name,
                Otch = worker.Otch,
                Post = worker.Post,
                Subunit = worker.Sector.Subunit.Id,
                Sector = worker.Sector.Id,
                AllRoles = _roleManager.Roles.ToList(),
                UserRoles = await _userManager.GetRolesAsync(worker)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                Worker worker = await _userManager.FindByIdAsync(model.Id);
                if (worker != null)
                {
                    worker.Family = model.Family;
                    worker.Name = model.Name;
                    worker.Otch = model.Otch;
                    worker.Post = model.Post;
                    worker.SectorId = model.Sector;

                    var result = await _userManager.UpdateAsync(worker);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(worker);
                        var addedRoles = roles.Except(userRoles);
                        var removedRoles = userRoles.Except(roles);
                        await _userManager.AddToRolesAsync(worker, addedRoles);
                        await _userManager.RemoveFromRolesAsync(worker, removedRoles);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError("", error.Description);

                        model.FillLists(db);
                        model.AllRoles = _roleManager.Roles.ToList();
                        model.UserRoles = await _userManager.GetRolesAsync(worker);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return View(model);
        }
    }
}