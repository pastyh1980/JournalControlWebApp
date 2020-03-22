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
            //IQueryable<Worker> workers = _userManager.Users;
            IQueryable<Worker>  workers = db.Workers.Include(x => x.Sector).Include(x => x.Sector.Subunit);
            /*foreach (var worker in workers)
            {
                db.Entry(worker).Reference(w => w.Sector).Load();
                db.Entry(worker.Sector).Reference(s => s.Subunit).Load();
            }*/

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

            switch(sortOrder)
            {
                case SortStateWorker.LoginDesc:
                    workers = workers.OrderByDescending(p => p.UserName);
                    break;

                case SortStateWorker.FamilyAsc:
                    workers = workers.OrderBy(p => p.Family);
                    break;

                case SortStateWorker.FamilyDesc:
                    workers = workers.OrderByDescending(p => p.Family);
                    break;

                case SortStateWorker.NameAsc:
                    workers = workers.OrderBy(p => p.Name);
                    break;

                case SortStateWorker.NameDesc:
                    workers = workers.OrderByDescending(p => p.Name);
                    break;

                case SortStateWorker.OtchAsc:
                    workers = workers.OrderBy(p => p.Otch);
                    break;

                case SortStateWorker.OtchDesc:
                    workers = workers.OrderByDescending(p => p.Otch);
                    break;

                case SortStateWorker.PostAsc:
                    workers = workers.OrderBy(p => p.Post);
                    break;

                case SortStateWorker.PostDesc:
                    workers = workers.OrderByDescending(p => p.Post);
                    break;

                case SortStateWorker.SubunitAsc:
                    workers = workers.OrderBy(p => p.Sector.Subunit.Name);
                    break;

                case SortStateWorker.SubunitDesc:
                    workers = workers.OrderByDescending(p => p.Sector.Subunit.Name);
                    break;

                case SortStateWorker.SectorAsc:
                    workers = workers.OrderBy(p => p.UserName);
                    break;

                case SortStateWorker.SectorDesc:
                    workers = workers.OrderByDescending(p => p.UserName);
                    break;

                default:
                    workers = workers.OrderBy(p => p.UserName);
                    break;
            }

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