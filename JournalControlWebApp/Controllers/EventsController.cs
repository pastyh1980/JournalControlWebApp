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
    public class EventsController : Controller
    {

        private readonly UserManager<Worker> _userManager;
        private readonly journalContext db;

        public EventsController(UserManager<Worker> userManager, journalContext context)
        {
            _userManager = userManager;
            db = context;
        }

        [Authorize(Roles = "EVENT_DETAIL,DEVEL,CONTROL")]
        public async Task<IActionResult> Index(int? subunit, int? sector, string query, int page = 1, SortStateEvent sortOrder = SortStateEvent.FailCountAsc)
        {
            int pageSize = 10;
            IQueryable<Event> events = db.Events
                .Include(e => e.Check)
                .Include(e => e.DeveloperNavigation)
                .Include(e => e.Check.Sector)
                .Include(e => e.Check.Sector.Subunit)
                .Include(e => e.DeveloperNavigation.Sector)
                .Include(e => e.DeveloperNavigation.Sector.Subunit);

            events = events.Where(e => e.IsActive && e.IsCorrect);
            if (User.IsInRole("DEVEL") && !User.IsInRole("EVENT_DETAIL") && !User.IsInRole("CONTROL"))
            {
                Worker worker = await _userManager.FindByNameAsync(User.Identity.Name);
                if (worker != null)
                    events = events.Where(e => e.Developer == worker.Id);
            }
            else if (User.IsInRole("EVENT_DETAIL") && !User.IsInRole("CONTROL"))
            {
                Worker worker = await _userManager.FindByNameAsync(User.Identity.Name);
                db.Entry(worker).Reference(w => w.Sector).Load();
                if (worker != null)
                    events = events.Where(e => e.Check.Sector.SubunitId == worker.Sector.SubunitId);
            }

            if (subunit != null && subunit != 0)
            {
                events = events.Where(e => e.Check.Sector.SubunitId == subunit);

                if (sector != null && sector != 0)
                {
                    events = events.Where(e => e.Check.SectorId == sector);
                }
            }

            if (!String.IsNullOrEmpty(query))
            {
                events = events.Where(e => e.Check.FailCount.ToUpper().Contains(query.ToUpper())
                                        || e.Check.FailDescription.ToUpper().Contains(query.ToUpper())
                                        || e.Description.ToUpper().Contains(query.ToUpper())
                                        || e.ResponsWorker.ToUpper().Contains(query.ToUpper())
                                        || e.DeveloperNavigation.Sector.Subunit.Name.ToUpper().Contains(query.ToUpper())
                                        || e.DeveloperNavigation.Family.ToUpper().Contains(query.ToUpper())
                                        || e.Report.ToUpper().Contains(query.ToUpper()));
            }

            switch(sortOrder)
            {
                case SortStateEvent.FailCountDesc:
                    events = events.OrderByDescending(e => e.Check.FailCount);
                    break;
                case SortStateEvent.CheckSubunitAsc:
                    events = events.OrderBy(e => e.Check.Sector.Subunit.Name);
                    break;
                case SortStateEvent.CheckSubunitDesc:
                    events = events.OrderByDescending(e => e.Check.Sector.Subunit.Name);
                    break;
                case SortStateEvent.CheckSectorAsc:
                    events = events.OrderBy(e => e.Check.Sector.SectorName);
                    break;
                case SortStateEvent.CheckSectorDesc:
                    events = events.OrderByDescending(e => e.Check.Sector.SectorName);
                    break;
                case SortStateEvent.FailDescriptionAsc:
                    events = events.OrderBy(e => e.Check.FailDescription);
                    break;
                case SortStateEvent.FailDescriptionDesc:
                    events = events.OrderByDescending(e => e.Check.FailDescription);
                    break;
                case SortStateEvent.EventDescriptionAsc:
                    events = events.OrderBy(e => e.Description);
                    break;
                case SortStateEvent.EventDescriptionDesc:
                    events = events.OrderByDescending(e => e.Description);
                    break;
                case SortStateEvent.ResponseWorkerAsc:
                    events = events.OrderBy(e => e.ResponsWorker);
                    break;
                case SortStateEvent.ResponseWorkerDesc:
                    events = events.OrderByDescending(e => e.ResponsWorker);
                    break;
                case SortStateEvent.DueDateAsc:
                    events = events.OrderBy(e => e.DueDate);
                    break;
                case SortStateEvent.DueDateDesc:
                    events = events.OrderByDescending(e => e.DueDate);
                    break;
                case SortStateEvent.DeveloperSubunitAsc:
                    events = events.OrderBy(e => e.DeveloperNavigation.Sector.Subunit.Name);
                    break;
                case SortStateEvent.DeveloperSubunitDesc:
                    events = events.OrderByDescending(e => e.DeveloperNavigation.Sector.Subunit.Name);
                    break;
                case SortStateEvent.DeveloperAsc:
                    events = events.OrderBy(e => e.DeveloperNavigation.Family);
                    break;
                case SortStateEvent.DeveloperDesc:
                    events = events.OrderByDescending(e => e.DeveloperNavigation.Family);
                    break;
                case SortStateEvent.ReportAsc:
                    events = events.OrderBy(e => e.Report);
                    break;
                case SortStateEvent.ReportDesc:
                    events = events.OrderByDescending(e => e.Report);
                    break;

                default:
                    events = events.OrderBy(e => e.Check.FailCount);
                    break;
            }

            var count = await events.CountAsync();
            var items = await events.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            EventListViewModel model = new EventListViewModel
            {
                FilterViewModel = new FilterEventViewModel(db.Subunits.ToList(), db.Sectors.ToList(), subunit, sector, query),
                SortViewModel = new SortEventViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, pageSize),
                Events = items
            };

            return View(model);
        }

        [Authorize(Roles = "DEVEL")]
        [HttpGet]
        public async Task<IActionResult> Create(int? subunit, int? sector, string query, int page = 1, SortStateCheck sortOrder = SortStateCheck.FailCountAsc)
        {
            int pageSize = 10;
            IQueryable<Check> checks = db.Check.Include(c => c.RegWorkerNavigation)
                .Include(c => c.RegWorkerNavigation.Sector)
                .Include(c => c.RegWorkerNavigation.Sector.Subunit)
                .Include(c => c.Sector)
                .Include(c => c.Sector.Subunit)
                .Include(c => c.Shows);

            checks = checks.Where(c => c.IsActive && c.IsCorrect && c.IsFail && c.Shows.Count > 0);
            
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

            switch (sortOrder)
            {
                case SortStateCheck.FailCountDesc:
                    checks = checks.OrderByDescending(c => c.FailCount);
                    break;

                case SortStateCheck.CheckSubunitAsc:
                    checks = checks.OrderBy(c => c.Sector.Subunit.Name);
                    break;

                case SortStateCheck.CheckSubunitDesc:
                    checks = checks.OrderByDescending(c => c.Sector.Subunit.Name);
                    break;

                case SortStateCheck.CheckDateAsc:
                    checks = checks.OrderBy(c => c.CheckDate);
                    break;

                case SortStateCheck.CheckDateDesc:
                    checks = checks.OrderByDescending(c => c.CheckDate);
                    break;

                case SortStateCheck.SectorAsc:
                    checks = checks.OrderBy(c => c.Sector.SectorName);
                    break;

                case SortStateCheck.SectorDesc:
                    checks = checks.OrderByDescending(c => c.Sector.SectorName);
                    break;

                case SortStateCheck.RegWorkerAsc:
                    checks = checks.OrderBy(c => c.RegWorkerNavigation.Family);
                    break;

                case SortStateCheck.RegWorkerDesc:
                    checks = checks.OrderByDescending(c => c.RegWorkerNavigation.Family);
                    break;

                case SortStateCheck.ControlIndicatorAsc:
                    checks = checks.OrderBy(c => c.ControlIndicator);
                    break;

                case SortStateCheck.ControlIndicatorDesc:
                    checks = checks.OrderByDescending(c => c.ControlIndicator);
                    break;

                case SortStateCheck.FailDescriptionAsc:
                    checks = checks.OrderBy(c => c.FailDescription);
                    break;

                case SortStateCheck.FailDescriptionDesc:
                    checks = checks.OrderByDescending(c => c.FailDescription);
                    break;

                case SortStateCheck.RegSubunitAsc:
                    checks = checks.OrderBy(c => c.RegWorkerNavigation.Sector.Subunit.Name);
                    break;

                case SortStateCheck.RegSubunitDesc:
                    checks = checks.OrderByDescending(c => c.RegWorkerNavigation.Sector.Subunit.Name);
                    break;

                default:
                    checks = checks.OrderBy(c => c.FailCount);
                    break;
            }

            var count = await checks.CountAsync();
            var items = await checks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            CreateEventViewModel model = new CreateEventViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortCheckViewModel(sortOrder),
                FilterViewModel = new FilterCheckViewModel(db.Subunits.ToList(), db.Sectors.ToList(), subunit, sector, query),
                Checks = items,
                DueDate = DateTime.Now.Date
            };

            return View(model);
        }

        [Authorize(Roles = "DEVEL")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);

                if (currentWorker == null)
                    return BadRequest();

                Event ev = new Event
                {
                    CheckId = model.SelectedCheckId ?? 0,
                    FailReason = model.FailReason,
                    Description = model.Description,
                    ResponsWorker = model.ResponseWorker,
                    DueDate = model.DueDate,
                    IsActive = true,
                    IsCorrect = true,
                    Developer = currentWorker.Id,
                    DevelopDate = DateTime.Now
                };

                db.Events.Add(ev);
                try
                {
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", "Ошибка добавления");
                }
            }

            int pageSize = 10;
            IQueryable<Check> checks = db.Check.Include(c => c.RegWorkerNavigation)
                .Include(c => c.RegWorkerNavigation.Sector)
                .Include(c => c.RegWorkerNavigation.Sector.Subunit)
                .Include(c => c.Sector)
                .Include(c => c.Sector.Subunit)
                .Include(c => c.Shows);
            checks = checks.Where(c => c.IsActive && c.IsCorrect && c.IsFail && c.Shows.Count > 0);
            var count = await checks.CountAsync();
            model.Checks = await checks.Take(pageSize).ToListAsync();
            model.PageViewModel = new PageViewModel(count, 1, pageSize);
            model.SortViewModel = new SortCheckViewModel(SortStateCheck.FailCountAsc);
            model.FilterViewModel = new FilterCheckViewModel(db.Subunits.ToList(), db.Sectors.ToList(), 0, 0, "");
            return View(model);
        }

        [Authorize(Roles = "DEVEL,EVENT_DETAIL,CONTROL")]
        public async Task<IActionResult> Details(int id)
        {
            Event ev = db.Events.Find(id);
            if (ev != null)
            {
                db.Entry(ev).Reference(e => e.Check).Load();
                db.Entry(ev.Check).Reference(e => e.Sector).Load();
                db.Entry(ev.Check.Sector).Reference(e => e.Subunit).Load();
                db.Entry(ev.Check).Reference(e => e.RegWorkerNavigation).Load();
                db.Entry(ev).Reference(e => e.DeveloperNavigation).Load();
                db.Entry(ev.DeveloperNavigation).Reference(e => e.Sector).Load();
                db.Entry(ev.DeveloperNavigation.Sector).Reference(e => e.Subunit).Load();
                db.Entry(ev).Reference(e => e.ReportWorkerNavigation).Load();
                if (ev.ReportWorkerNavigation != null)
                {
                    db.Entry(ev.ReportWorkerNavigation).Reference(e => e.Sector).Load();
                    db.Entry(ev.ReportWorkerNavigation.Sector).Reference(e => e.Subunit).Load();
                }

                Worker currentWorker = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentWorker != null)
                {
                    db.Entry(currentWorker).Reference(w => w.Sector).Load();
                    db.Entry(currentWorker.Sector).Reference(w => w.Subunit).Load();
                    ViewBag.Worker = currentWorker;

                    return View(ev);
                }
                return BadRequest();
            }
            return NotFound();
        }
    }
}