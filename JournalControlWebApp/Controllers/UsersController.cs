using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using JournalControlWebApp.Models.ViewModel;
using JournalControlWebApp.Models.dbo;
using JournalControlWebApp.Models.FSPViewModel;

namespace JournalControlWebApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
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

        public IActionResult Index(string query, int page = 1, SortStateWorker sortOrder = SortStateWorker.LoginAsc)
        {
            int pageSize = 10;
            IQueryable<Worker>  workers = db.Workers.Include(x => x.Sector).Include(x => x.Sector.Subunit);

            if (!String.IsNullOrEmpty(query))
            {
                workers = workers.Where(p => p.UserName.ToUpper().Contains(query.ToUpper())
                                || p.Family.ToUpper().Contains(query.ToUpper())
                                || p.Name.ToUpper().Contains(query.ToUpper())
                                || p.Otch.ToUpper().Contains(query.ToUpper())
                                || p.Post.ToUpper().Contains(query.ToUpper())
                                || p.Sector.Subunit.Name.ToUpper().Contains(query.ToUpper())
                                || p.Sector.SectorName.ToUpper().Contains(query.ToUpper())
                );
            }

            workers = sortOrder switch
            {
                SortStateWorker.LoginDesc => workers.OrderByDescending(p => p.UserName),
                SortStateWorker.FamilyAsc => workers.OrderBy(p => p.Family),
                SortStateWorker.FamilyDesc => workers.OrderByDescending(p => p.Family),
                SortStateWorker.NameAsc => workers.OrderBy(p => p.Name),
                SortStateWorker.NameDesc => workers.OrderByDescending(p => p.Name),
                SortStateWorker.OtchAsc => workers.OrderBy(p => p.Otch),
                SortStateWorker.OtchDesc => workers.OrderByDescending(p => p.Otch),
                SortStateWorker.PostAsc => workers.OrderBy(p => p.Post),
                SortStateWorker.PostDesc => workers.OrderByDescending(p => p.Post),
                SortStateWorker.SubunitAsc => workers.OrderBy(p => p.Sector.Subunit.Name),
                SortStateWorker.SubunitDesc => workers.OrderByDescending(p => p.Sector.Subunit.Name),
                SortStateWorker.SectorAsc => workers.OrderBy(p => p.UserName),
                SortStateWorker.SectorDesc => workers.OrderByDescending(p => p.UserName),
                _ => workers.OrderBy(p => p.UserName),
            };
            var count = workers.Count();
            var items = workers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            WorkerListViewModel model = new WorkerListViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortWorkerViewModel(sortOrder),
                FilterViewModel = new FilterWorkerViewModel(query),
                Workers = items
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            CreateUserViewModel model = new CreateUserViewModel(db)
            {
                AllRoles = _roleManager.Roles.ToList()
            };
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
            model.AllRoles = _roleManager.Roles.ToList();
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

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            Worker worker = await _userManager.FindByIdAsync(id);
            if (worker != null)
            {
                ChangePasswordViewModel model = new ChangePasswordViewModel { Id = worker.Id.ToString(), Login = worker.UserName };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
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
                        worker.IsFirstLogin = true;
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
        public async Task<IActionResult> DeleteUser(string id)
        {
            Worker worker = await _userManager.FindByIdAsync(id);
            
            if (worker != null)
            {
                await _userManager.DeleteAsync(worker);
            }
            return NotFound();
        }
    }
}