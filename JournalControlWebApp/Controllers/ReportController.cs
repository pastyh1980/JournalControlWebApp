using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using OfficeOpenXml;
using OfficeOpenXml.Style;

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

        public async Task<IActionResult> EventList()
        {
            return NotFound();
        }

        public async Task<IActionResult> Check(int id)
        {
            return NotFound();
        }

        public async Task<IActionResult> Event(int id)
        {
            return NotFound();
        }

        public async Task<IActionResult> CreateReport()
        {
            IQueryable<Check> CheckList = db.Check.Include(c => c.RegWorkerNavigation)
                .Include(c => c.RegWorkerNavigation.Sector)
                .Include(c => c.RegWorkerNavigation.Sector.Subunit)
                .Include(c => c.Sector)
                .Include(c => c.Sector.Subunit)
                .Include(c => c.Events)
                .Include(c => c.DeleteWorkerNavigation)
                .Include(c => c.Shows);

            foreach (Check ch in CheckList)
            {
                if (ch.DeleteWorkerNavigation != null)
                {
                    db.Entry(ch.DeleteWorkerNavigation).Reference(w => w.Sector).Load();
                    db.Entry(ch.DeleteWorkerNavigation.Sector).Reference(s => s.Subunit).Load();
                }

                foreach (Event ev in ch.Events)
                {
                    db.Entry(ev).Reference(e => e.DeveloperNavigation).Load();
                    db.Entry(ev.DeveloperNavigation).Reference(w => w.Sector).Load();
                    db.Entry(ev.DeveloperNavigation.Sector).Reference(s => s.Subunit).Load();


                    db.Entry(ev).Reference(e => e.ReportWorkerNavigation).Load();
                    if (ev.ReportWorkerNavigation != null)
                    {
                        db.Entry(ev.ReportWorkerNavigation).Reference(w => w.Sector).Load();
                        db.Entry(ev.ReportWorkerNavigation.Sector).Reference(s => s.Subunit).Load();
                    }

                    db.Entry(ev).Reference(e => e.DeleteWorkerNavigation).Load();
                    if (ev.DeleteWorkerNavigation != null)
                    {
                        db.Entry(ev.DeleteWorkerNavigation).Reference(w => w.Sector).Load();
                        db.Entry(ev.DeleteWorkerNavigation.Sector).Reference(s => s.Subunit).Load();
                    }
                }

                foreach (Show sh in ch.Shows)
                {
                    db.Entry(sh).Reference(s => s.Worker).Load();
                    db.Entry(sh.Worker).Reference(w => w.Sector).Load();
                    db.Entry(sh.Worker.Sector).Reference(s => s.Subunit).Load();
                }
            }

            byte[] reportContent = createXlsx(CheckList);

            string fileName = "Отчет_" + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

            if (reportContent != null && reportContent.Length > 0)
                return File(
                    fileContents: reportContent,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: fileName);

            return NotFound();
        }

        private byte[] createXlsx(IQueryable<Check> checks)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContent;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет");
                ExcelRange cells;

                #region Header

                cells = worksheet.Cells[1, 1]; //Выбор ячейки
                cells.Value = "Номер несоответствия"; //Текст
                worksheet.Column(1).Width = 16; //Ширина в относительных единицах Excel (не пиксели и не милиметры)
                createBorders(cells); //Создание границ ячеек

                cells = worksheet.Cells[1, 2];
                cells.Value = "Дата проверки";
                worksheet.Column(2).Width = 11;
                createBorders(cells);

                cells = worksheet.Cells[1, 3];
                cells.Value = "Проверяемое подразделение";
                worksheet.Column(3).Width = 16;
                createBorders(cells);

                cells = worksheet.Cells[1, 4];
                cells.Value = "Проверяемый участок";
                worksheet.Column(4).Width = 16;
                createBorders(cells);

                cells = worksheet.Cells[1, 5];
                cells.Value = "Объект контроля";
                worksheet.Column(5).Width = 24;
                createBorders(cells);

                cells = worksheet.Cells[1, 6];
                cells.Value = "Результат контроля";
                worksheet.Column(6).Width = 28;
                createBorders(cells);

                cells = worksheet.Cells[1, 7];
                cells.Value = "Обозначение комплекта документов (ТД, КД)";
                worksheet.Column(7).Width = 14;
                createBorders(cells);

                cells = worksheet.Cells[1, 8];
                cells.Value = "ФИО проверяющего";
                worksheet.Column(8).Width = 16;
                createBorders(cells);

                cells = worksheet.Cells[1, 9];
                cells.Value = "Подразделение регистрирующего сотрудника";
                worksheet.Column(9).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 10];
                cells.Value = "ФИО и должность регистрирующего сотрудника";
                worksheet.Column(10).Width = 21;
                createBorders(cells);

                cells = worksheet.Cells[1, 11];
                cells.Value = "Дата регистрации несоответствия";
                worksheet.Column(11).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 12];
                cells.Value = "Дата удаления несоответствия";
                worksheet.Column(12).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 13];
                cells.Value = "Причина удаления несоответствия";
                worksheet.Column(13).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 14];
                cells.Value = "ФИО и должность удалившего несоответствие сотрудника";
                worksheet.Column(14).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 15];
                cells.Value = "Подразделение удалившего несоответствие сотрудника";
                worksheet.Column(15).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 16];
                cells.Value = "Дата ознакомления";
                worksheet.Column(16).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 17];
                cells.Value = "ФИО и должность ознакомившегося";
                worksheet.Column(17).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 18];
                cells.Value = "Подразделение ознакомившегося";
                worksheet.Column(18).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 19];
                cells.Value = "Причина несоответствия";
                worksheet.Column(19).Width = 24;
                createBorders(cells);

                cells = worksheet.Cells[1, 20];
                cells.Value = "Описание мероприятия";
                worksheet.Column(20).Width = 28;
                createBorders(cells);

                cells = worksheet.Cells[1, 21];
                cells.Value = "Ответственный";
                worksheet.Column(21).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 22];
                cells.Value = "Срок исполнения";
                worksheet.Column(22).Width = 14;
                createBorders(cells);

                cells = worksheet.Cells[1, 23];
                cells.Value = "Дата разработки";
                worksheet.Column(23).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 24];
                cells.Value = "ФИО и должность разработчика";
                worksheet.Column(24).Width = 16;
                createBorders(cells);

                cells = worksheet.Cells[1, 25];
                cells.Value = "Подразделение разработчика";
                worksheet.Column(25).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 26];
                cells.Value = "Отчет";
                worksheet.Column(26).Width = 13;
                createBorders(cells);

                cells = worksheet.Cells[1, 27];
                cells.Value = "Подтверждающая информация";
                worksheet.Column(27).Width = 20;
                createBorders(cells);

                cells = worksheet.Cells[1, 28];
                cells.Value = "Дата отчета";
                worksheet.Column(28).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 29];
                cells.Value = "ФИО и должность сотрудника, предоставившего отчет";
                worksheet.Column(29).Width = 20;
                createBorders(cells);

                cells = worksheet.Cells[1, 30];
                cells.Value = "Подразделение сотрудника, предоставившего отчет";
                worksheet.Column(30).Width = 20;
                createBorders(cells);

                cells = worksheet.Cells[1, 31];
                cells.Value = "Дата удаления";
                worksheet.Column(31).Width = 17;
                createBorders(cells);

                cells = worksheet.Cells[1, 32];
                cells.Value = "Причина удаления";
                worksheet.Column(32).Width = 20;
                createBorders(cells);

                cells = worksheet.Cells[1, 33];
                cells.Value = "ФИО и должность удалившего мероприятие сотрудника";
                worksheet.Column(33).Width = 20;
                createBorders(cells);

                cells = worksheet.Cells[1, 34];
                cells.Value = "Подразделение удалившего мероприятие сотрудника";
                worksheet.Column(34).Width = 17;
                createBorders(cells);

                #endregion

                //strNum - Текущая строка
                //startStr - Первая строка каждого несоответствия
                //endStr - последняя строка каждого несоответствия
                //showStrNum - Текущая строка ознакомления
                //eventStrNum - Текущая строка мероприятия
                int strNum = 2, startStr = 2, endStr, showStrNum = 2, eventStrNum = 2;

                foreach (Check str in checks)
                {
                    if (strNum != 2)
                    {
                        //Последняя строка - большая из ознакомлений и мероприятий минус один
                        endStr = showStrNum > eventStrNum ? showStrNum - 1 : eventStrNum - 1;
                        if (strNum < showStrNum || strNum < eventStrNum) //Присвоение strNum следующего значения, если он меньше ознакомлений или мероприятий
                            strNum = showStrNum > eventStrNum ? showStrNum : eventStrNum;
                        //endStr не должен быть меньше startStr
                        if (endStr < startStr) endStr = startStr;

                        #region Объединение ячеек
                        cells = worksheet.Cells["A" + startStr.ToString() + ":A" + endStr.ToString()]; //Выбор всех ячеек одного столбца текущего несоответствия
                        cells.Merge = true; //Объединение ячеек
                        createBorders(cells); //Создание общей рамки

                        cells = worksheet.Cells["B" + startStr.ToString() + ":B" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["C" + startStr.ToString() + ":C" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["D" + startStr.ToString() + ":D" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["E" + startStr.ToString() + ":E" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["F" + startStr.ToString() + ":F" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["G" + startStr.ToString() + ":G" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["H" + startStr.ToString() + ":H" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["I" + startStr.ToString() + ":I" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["J" + startStr.ToString() + ":J" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["K" + startStr.ToString() + ":K" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["L" + startStr.ToString() + ":L" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["M" + startStr.ToString() + ":M" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["N" + startStr.ToString() + ":N" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["O" + startStr.ToString() + ":O" + endStr.ToString()];
                        cells.Merge = true;
                        createBorders(cells);

                        cells = worksheet.Cells["P" + startStr.ToString() + ":P" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["Q" + startStr.ToString() + ":Q" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["R" + startStr.ToString() + ":R" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["S" + startStr.ToString() + ":S" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["T" + startStr.ToString() + ":T" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["U" + startStr.ToString() + ":U" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["V" + startStr.ToString() + ":V" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["W" + startStr.ToString() + ":W" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["X" + startStr.ToString() + ":X" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["Y" + startStr.ToString() + ":Y" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["Z" + startStr.ToString() + ":Z" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AA" + startStr.ToString() + ":AA" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AB" + startStr.ToString() + ":AB" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AC" + startStr.ToString() + ":AC" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AD" + startStr.ToString() + ":AD" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AE" + startStr.ToString() + ":AE" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AF" + startStr.ToString() + ":AF" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AG" + startStr.ToString() + ":AG" + endStr.ToString()];
                        createBorders(cells);

                        cells = worksheet.Cells["AH" + startStr.ToString() + ":AH" + endStr.ToString()];
                        createBorders(cells);
                        #endregion

                        startStr = strNum; //Новый startStr
                    }

                    #region Заполнение данными
                    cells = worksheet.Cells[strNum, 1];
                    cells.Value = str.FailCount;

                    cells = worksheet.Cells[strNum, 3];
                    cells.Value = str.Sector.Subunit.Name;

                    cells = worksheet.Cells[strNum, 4];
                    cells.Value = str.Sector.SectorName;

                    cells = worksheet.Cells[strNum, 2];
                    cells.Value = str.CheckDate.ToShortDateString();

                    cells = worksheet.Cells[strNum, 8];
                    cells.Value = "-";

                    cells = worksheet.Cells[strNum, 7];
                    cells.Value = str.TdKd;

                    cells = worksheet.Cells[strNum, 5];
                    cells.Value = str.ControlIndicator;

                    cells = worksheet.Cells[strNum, 6];
                    cells.Value = str.FailDescription;

                    cells = worksheet.Cells[strNum, 11];
                    cells.Value = str.RegDate.ToShortDateString() + " " + str.RegDate.ToShortTimeString();

                    cells = worksheet.Cells[strNum, 10];
                    cells.Value = workerFio(str.RegWorkerNavigation);

                    cells = worksheet.Cells[strNum, 9];
                    cells.Value = str.RegWorkerNavigation.Sector.Subunit.Name;

                    if (str.DeleteDate != null) //Пустая дата отображается некорректно
                    {
                        DateTime delDate = (DateTime)str.DeleteDate;
                        cells = worksheet.Cells[strNum, 12];
                        cells.Value = delDate.ToShortDateString() + " " + delDate.ToShortTimeString();

                        cells = worksheet.Cells[strNum, 14];
                        cells.Value = workerFio(str.DeleteWorkerNavigation);

                        cells = worksheet.Cells[strNum, 15];
                        cells.Value = str.DeleteWorkerNavigation.Sector.Subunit.Name;
                    }

                    cells = worksheet.Cells[strNum, 13];
                    cells.Value = str.IsActive && str.IsCorrect ? "-" : !str.IsCorrect ? "Ошибка" : "Устранение";

                    showStrNum = strNum;

                    foreach (Show show in str.Shows)
                    {
                        cells = worksheet.Cells[showStrNum, 16];
                        cells.Value = show.Date.ToShortDateString() + " " + show.Date.ToShortTimeString();

                        cells = worksheet.Cells[showStrNum, 17];
                        cells.Value = workerFio(show.Worker);

                        cells = worksheet.Cells[showStrNum, 18];
                        cells.Value = show.Worker.Sector.Subunit.Name;

                        ++showStrNum;
                    }

                    eventStrNum = strNum;

                    foreach (Event eventt in str.Events)
                    {
                        cells = worksheet.Cells[eventStrNum, 19];
                        cells.Value = eventt.FailReason;

                        cells = worksheet.Cells[eventStrNum, 20];
                        cells.Value = eventt.Description;

                        cells = worksheet.Cells[eventStrNum, 21];
                        cells.Value = eventt.ResponsWorker;

                        cells = worksheet.Cells[eventStrNum, 22];
                        cells.Value = eventt.DueDate.ToShortDateString();

                        cells = worksheet.Cells[eventStrNum, 23];
                        cells.Value = eventt.DevelopDate.ToShortDateString() + " " + eventt.DevelopDate.ToShortTimeString();

                        cells = worksheet.Cells[eventStrNum, 24];
                        cells.Value = workerFio(eventt.DeveloperNavigation);

                        cells = worksheet.Cells[eventStrNum, 25];
                        cells.Value = eventt.DeveloperNavigation.Sector.Subunit.Name;

                        cells = worksheet.Cells[eventStrNum, 26];
                        cells.Value = eventt.Report;

                        cells = worksheet.Cells[eventStrNum, 27];
                        cells.Value = eventt.ProofInf;

                        if (eventt.Report != null && eventt.Report != "")
                        {
                            cells = worksheet.Cells[eventStrNum, 28];
                            cells.Value = ((DateTime)eventt.ReportDate).ToShortDateString() + " " + ((DateTime)eventt.ReportDate).ToShortTimeString();

                            cells = worksheet.Cells[eventStrNum, 29];
                            cells.Value = workerFio(eventt.ReportWorkerNavigation);

                            cells = worksheet.Cells[eventStrNum, 30];
                            cells.Value = eventt.ReportWorkerNavigation.Sector.Subunit.Name;
                        }

                        if (eventt.DeleteDate != null)
                        {
                            cells = worksheet.Cells[eventStrNum, 33];
                            cells.Value = workerFio(eventt.DeleteWorkerNavigation);

                            cells = worksheet.Cells[eventStrNum, 31];
                            cells.Value = ((DateTime)eventt.DeleteDate).ToShortDateString() + " " + ((DateTime)eventt.DeleteDate).ToShortTimeString();

                            cells = worksheet.Cells[eventStrNum, 34];
                            cells.Value = eventt.DeleteWorkerNavigation.Sector.Subunit.Name;
                        }

                        cells = worksheet.Cells[eventStrNum, 32];
                        cells.Value = eventt.IsActive && eventt.IsCorrect ? "-" : !eventt.IsCorrect ? "Ошибка" : "Устранение";

                        ++eventStrNum;
                    }
                    #endregion
                    ++strNum;
                }

                if (strNum != 2)
                {
                    //Последняя строка - большая из ознакомлений и мероприятий минус один
                    endStr = showStrNum > eventStrNum ? showStrNum - 1 : eventStrNum - 1;
                    if (strNum < showStrNum || strNum < eventStrNum) //Присвоение strNum следующего значения, если он меньше ознакомлений или мероприятий
                        strNum = showStrNum > eventStrNum ? showStrNum : eventStrNum;
                    //endStr не должен быть меньше startStr
                    if (endStr < startStr) endStr = startStr;

                    #region Объединение ячеек
                    cells = worksheet.Cells["A" + startStr.ToString() + ":A" + endStr.ToString()]; //Выбор всех ячеек одного столбца текущего несоответствия
                    cells.Merge = true; //Объединение ячеек
                    createBorders(cells); //Создание общей рамки

                    cells = worksheet.Cells["B" + startStr.ToString() + ":B" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["C" + startStr.ToString() + ":C" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["D" + startStr.ToString() + ":D" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["E" + startStr.ToString() + ":E" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["F" + startStr.ToString() + ":F" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["G" + startStr.ToString() + ":G" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["H" + startStr.ToString() + ":H" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["I" + startStr.ToString() + ":I" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["J" + startStr.ToString() + ":J" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["K" + startStr.ToString() + ":K" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["L" + startStr.ToString() + ":L" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["M" + startStr.ToString() + ":M" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["N" + startStr.ToString() + ":N" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["O" + startStr.ToString() + ":O" + endStr.ToString()];
                    cells.Merge = true;
                    createBorders(cells);

                    cells = worksheet.Cells["P" + startStr.ToString() + ":P" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["Q" + startStr.ToString() + ":Q" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["R" + startStr.ToString() + ":R" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["S" + startStr.ToString() + ":S" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["T" + startStr.ToString() + ":T" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["U" + startStr.ToString() + ":U" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["V" + startStr.ToString() + ":V" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["W" + startStr.ToString() + ":W" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["X" + startStr.ToString() + ":X" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["Y" + startStr.ToString() + ":Y" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["Z" + startStr.ToString() + ":Z" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AA" + startStr.ToString() + ":AA" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AB" + startStr.ToString() + ":AB" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AC" + startStr.ToString() + ":AC" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AD" + startStr.ToString() + ":AD" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AE" + startStr.ToString() + ":AE" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AF" + startStr.ToString() + ":AF" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AG" + startStr.ToString() + ":AG" + endStr.ToString()];
                    createBorders(cells);

                    cells = worksheet.Cells["AH" + startStr.ToString() + ":AH" + endStr.ToString()];
                    createBorders(cells);
                    #endregion
                }

                cells = worksheet.Cells["A1:AI65536"];//Выбор всех ячеек
                cells.Style.WrapText = true;//Включение переноса по словам
                //Выравнивание по центру ячейки
                cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                fileContent = package.GetAsByteArray();
            }

            return fileContent;
        }

        private void createBorders(ExcelRange cells)
        {
            cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }

        private string workerFio(Worker worker)
        {
            return worker.Family + " " + worker.Name[0] + "." + worker.Otch[0] + ".";
        }
    }
}