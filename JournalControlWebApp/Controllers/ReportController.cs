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
    [Authorize(Roles = "CONTROL")]
    public class ReportController : Controller
    {

        private readonly journalContext db;

        public ReportController(journalContext context)
        {
            db = context;
        }

        public async Task<IActionResult> CheckList(int? subunit, int? sector, int? deleted, string query, int page = 1, SortStateCheck sortOrder = SortStateCheck.FailCountAsc)
        {
            int pageSize = 10;
            IQueryable<Check> checks = db.Check.Include(c => c.RegWorkerNavigation)
                .Include(c => c.RegWorkerNavigation.Sector)
                .Include(c => c.RegWorkerNavigation.Sector.Subunit)
                .Include(c => c.Sector)
                .Include(c => c.Sector.Subunit)
                .Include(c => c.Events);

            if (subunit != null && subunit != 0)
            {
                checks = checks.Where(c => c.Sector.SubunitId == subunit);

                if (sector != null && sector != 0)
                {
                    checks = checks.Where(c => c.SectorId == sector);
                }
            }

            switch(deleted)
            {
                case 1:
                    checks = checks.Where(c => c.IsActive && c.IsCorrect);
                    break;

                case 2:
                    checks = checks.Where(c => !c.IsActive);
                    break;

                case 3:
                    checks = checks.Where(c => !c.IsCorrect);
                    break;
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

                case SortStateCheck.DeleteReasonAsc:
                    checks = checks.OrderBy(c => c.IsActive).OrderBy(c => c.IsCorrect);
                    break;

                case SortStateCheck.DeleteReasonDesc:
                    checks = checks.OrderByDescending(c => c.IsActive).OrderByDescending(c => c.IsCorrect);
                    break;

                default:
                    checks = checks.OrderBy(c => c.FailCount);
                    break;
            }

            var count = await checks.CountAsync();
            var items = await checks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            CheckListViewModel model = new CheckListViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortCheckViewModel(sortOrder),
                FilterViewModel = new FilterCheckViewModel(db.Subunits.ToList(), db.Sectors.ToList(), subunit, sector, query, deleted),
                Checks = items
            };

            return View(model);
        }
    }
}