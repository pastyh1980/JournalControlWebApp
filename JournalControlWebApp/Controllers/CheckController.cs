﻿using System;
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
    [Authorize]
    public class CheckController : Controller
    {

        private readonly UserManager<Worker> _userManager;
        private readonly journalContext db;

        public CheckController(UserManager<Worker> userManager, journalContext context)
        {
            _userManager = userManager;
            db = context;
        }

        [Authorize(Roles = "CONTROL,REG,CHECK_DETAIL")]
        [HttpGet]
        public async Task<IActionResult> Index(int? subunit, int? sector, string query, int page = 1, SortStateCheck sortOrder = SortStateCheck.FailCountAsc)
        {
            int pageSize = 10;
            IQueryable<Check> checks = db.Check.Include(c => c.RegWorkerNavigation)
                .Include(c => c.RegWorkerNavigation.Sector)
                .Include(c => c.RegWorkerNavigation.Sector.Subunit)
                .Include(c => c.Sector)
                .Include(c => c.Sector.Subunit)
                .Include(c => c.Events);
            checks = checks.Where(c => c.IsActive && c.IsCorrect);
            if (User.IsInRole("REG") && !User.IsInRole("CHECK_DETAIL") && !User.IsInRole("CONTROL")) 
            {
                Worker worker = await _userManager.FindByNameAsync(User.Identity.Name);
                if (worker != null)
                    checks = checks.Where(c => c.RegWorker == worker.Id);
            }
            else if (User.IsInRole("CHECK_DETAIL") && !User.IsInRole("CONTROL"))
            {
                Worker worker = await _userManager.FindByNameAsync(User.Identity.Name);
                if (worker != null)
                {
                    db.Entry(worker).Reference(w => w.Sector).Load();
                    checks = checks.Where(c => c.Sector.SubunitId == worker.Sector.SubunitId || c.RegWorker == worker.Id);
                }
            }

            if (subunit != null && subunit != 0)
            {
                checks = checks.Where(c => c.Sector.SubunitId == subunit);

                if (sector != null && sector != 0)
                {
                    checks = checks.Where(c => c.SectorId == sector);
                }
            }
            if (!String.IsNullOrEmpty(query))
            {
                checks = checks.Where(c => c.FailCount.ToUpper().Contains(query.ToUpper())
                                        || c.RegWorkerNavigation.Family.ToUpper().Contains(query.ToUpper())
                                        || c.ControlIndicator.ToUpper().Contains(query.ToUpper())
                                        || c.FailDescription.ToUpper().Contains(query.ToUpper())
                                        || c.RegWorkerNavigation.Sector.Subunit.Name.ToUpper().Contains(query.ToUpper())
                );
            }

            checks = sortOrder switch
            {
                SortStateCheck.FailCountDesc => checks.OrderByDescending(c => c.FailCount),
                SortStateCheck.CheckSubunitAsc => checks.OrderBy(c => c.Sector.Subunit.Name),
                SortStateCheck.CheckSubunitDesc => checks.OrderByDescending(c => c.Sector.Subunit.Name),
                SortStateCheck.CheckDateAsc => checks.OrderBy(c => c.CheckDate),
                SortStateCheck.CheckDateDesc => checks.OrderByDescending(c => c.CheckDate),
                SortStateCheck.SectorAsc => checks.OrderBy(c => c.Sector.SectorName),
                SortStateCheck.SectorDesc => checks.OrderByDescending(c => c.Sector.SectorName),
                SortStateCheck.RegWorkerAsc => checks.OrderBy(c => c.RegWorkerNavigation.Family),
                SortStateCheck.RegWorkerDesc => checks.OrderByDescending(c => c.RegWorkerNavigation.Family),
                SortStateCheck.ControlIndicatorAsc => checks.OrderBy(c => c.ControlIndicator),
                SortStateCheck.ControlIndicatorDesc => checks.OrderByDescending(c => c.ControlIndicator),
                SortStateCheck.FailDescriptionAsc => checks.OrderBy(c => c.FailDescription),
                SortStateCheck.FailDescriptionDesc => checks.OrderByDescending(c => c.FailDescription),
                SortStateCheck.RegSubunitAsc => checks.OrderBy(c => c.RegWorkerNavigation.Sector.Subunit.Name),
                SortStateCheck.RegSubunitDesc => checks.OrderByDescending(c => c.RegWorkerNavigation.Sector.Subunit.Name),
                _ => checks.OrderBy(c => c.FailCount),
            };
            var count = await checks.CountAsync();
            var items = await checks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            CheckListViewModel model = new CheckListViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortCheckViewModel(sortOrder),
                FilterViewModel = new FilterCheckViewModel(db.Subunits.ToList(), db.Sectors.ToList(), subunit, sector, query),
                Checks = items
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "REG")]
        public IActionResult Create()
        {
            CreateCheckViewModel model = new CreateCheckViewModel(db)
            {
                CheckDate = DateTime.Now.Date
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "REG")]
        public async Task<IActionResult> Create(CreateCheckViewModel model)
        {
            if (ModelState.IsValid)
            {
                string checkDate = model.CheckDate.ToString("yyMMdd");

                int num = 1;
                string failCount;

                do
                {
                    failCount = checkDate + num.ToString().PadLeft(2, '0');
                    ++num;
                } while (db.Check.Any(c => c.FailCount == failCount));

                Worker worker = await _userManager.FindByNameAsync(User.Identity.Name);

                if (worker == null)
                    return BadRequest();

                Check check = new Check
                {
                    FailCount = failCount,
                    RegWorker = worker.Id,
                    SectorId = model.SectorId,
                    RegDate = DateTime.Now,
                    CheckDate = model.CheckDate,
                    CheckWorker = "null",
                    TdKd = model.TDKD,
                    ControlIndicator = model.ControlIndicator,
                    FailDescription = model.FailDesc,
                    IsActive = true,
                    IsCorrect = true,
                    IsFail = model.isFail
                };

                db.Check.Add(check);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            model.FillLists(db);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "REG,CHECK_DETAIL,CONTROL")]
        public async Task<IActionResult> Details(int id)
        {
            Check check = db.Check.Find(id);
            if (check != null)
            {
                db.Entry(check).Reference(c => c.RegWorkerNavigation).Load();
                db.Entry(check.RegWorkerNavigation).Reference(c => c.Sector).Load();
                db.Entry(check.RegWorkerNavigation.Sector).Reference(c => c.Subunit).Load();
                db.Entry(check).Reference(c => c.DeleteWorkerNavigation).Load();
                if (check.DeleteWorkerNavigation != null)
                {
                    db.Entry(check.DeleteWorkerNavigation).Reference(c => c.Sector).Load();
                    db.Entry(check.DeleteWorkerNavigation.Sector).Reference(c => c.Subunit).Load();
                }
                db.Entry(check).Reference(c => c.Sector).Load();
                db.Entry(check.Sector).Reference(c => c.Subunit).Load();
                db.Entry(check).Collection(c => c.Events).Load();
                db.Entry(check).Collection(c => c.Shows).Load();

                //check.Events = check.Events.Where(e => e.IsCorrect && e.IsActive).ToList();

                foreach(Show show in check.Shows)
                {
                    db.Entry(show).Reference(s => s.Worker).Load();
                    db.Entry(show.Worker).Reference(s => s.Sector).Load();
                    db.Entry(show.Worker.Sector).Reference(s => s.Subunit).Load();
                }

                foreach(Event ev in check.Events)
                {
                    db.Entry(ev).Reference(e => e.DeveloperNavigation).Load();
                }

                Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentWorker != null)
                {
                    db.Entry(currentWorker).Reference(w => w.Sector).Load();
                    db.Entry(currentWorker.Sector).Reference(w => w.Subunit).Load();
                    ViewBag.Worker = currentWorker;

                    return View(check);
                }

                return BadRequest();
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "SUBSHOW")]
        public async Task<IActionResult> Subshow(int checkId)
        {
            Check check = db.Check.Find(checkId);
            Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);
            if (currentWorker != null && check != null)
            {
                db.Entry(currentWorker).Reference(w => w.Sector).Load();
                db.Entry(check).Reference(c => c.Sector).Load();
                db.Entry(check).Collection(c => c.Shows).Load();
                if (!check.Shows.Any(s => s.WorkerId == currentWorker.Id) && (currentWorker.SectorId == check.SectorId || currentWorker.Sector.SubunitId == check.Sector.SubunitId && currentWorker.Sector.IsMain))
                {
                    Show show = new Show
                    {
                        WorkerId = currentWorker.Id,
                        Date = DateTime.Now,
                        CheckId = checkId
                    };
                    db.Shows.Add(show);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Details", new { id = checkId });
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "SUBSHOW")]
        public async Task<IActionResult> Deactivate(int id)
        {
            Check check = db.Check.Find(id);
            Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);
            if (currentWorker != null && check != null)
            {
                db.Entry(currentWorker).Reference(w => w.Sector).Load();
                db.Entry(check).Reference(c => c.Sector).Load();
                db.Entry(check).Collection(c => c.Shows).Load();
                db.Entry(check).Collection(c => c.Events).Load();
                if (check.Shows.Count > 0 //Есть ознакомление
                    && (currentWorker.SectorId == check.SectorId || currentWorker.Sector.SubunitId == check.Sector.SubunitId && currentWorker.Sector.IsMain) //Сотрудник начальник сектора или начальник главного сектора
                    && (!check.IsFail || check.Events.Where(e => e.IsCorrect).Count() > 0 && !check.Events.Any(e => e.IsActive && e.IsCorrect))) //Несоответствий не обнаружено или есть хотя бы один корректный ивент и все ивенты завершены
                {
                    check.IsActive = false;
                    check.DeleteDate = DateTime.Now;
                    check.DeleteWorker = currentWorker.Id;

                    db.Check.Update(check);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Details", new { id });
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "REG")]
        public async Task<IActionResult> Incorrect(int id)
        {
            Check check = db.Check.Find(id);
            Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);
            if (currentWorker != null && check != null)
            {
                db.Entry(currentWorker).Reference(w => w.Sector).Load();
                db.Entry(check).Collection(c => c.Shows).Load();
                db.Entry(check).Collection(c => c.Events).Load();
                db.Entry(check).Reference(c => c.RegWorkerNavigation).Load();
                db.Entry(check.RegWorkerNavigation).Reference(w => w.Sector).Load();

                if (check.Shows.Count == 0 //Никто не ознакомился
                    && check.Events.Count == 0 //Нет мероприятий
                    && (check.RegWorker == currentWorker.Id || User.IsInRole("SUBSHOW")
                    && (currentWorker.SectorId == check.RegWorkerNavigation.SectorId
                    || currentWorker.Sector.SubunitId == check.RegWorkerNavigation.Sector.SubunitId && currentWorker.Sector.IsMain))) //Удалить может только создатель записи или его начальник
                {
                    check.IsCorrect = false;
                    check.DeleteDate = DateTime.Now;
                    check.DeleteWorker = currentWorker.Id;

                    db.Check.Update(check);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Details", new { id });
            }
            return BadRequest();
        }
    }
}