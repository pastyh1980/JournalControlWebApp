using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using JournalControlWebApp.Models.dbo;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JournalControlWebApp.Models.ViewModel
{
    public class CreateCheckViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата проверки")]
        public DateTime CheckDate { get; set; }

        [Required]
        [Display(Name = "Объект контроля")]
        public string ControlIndicator { get; set; }

        [Required]
        [Display(Name = "Описание несоответствия")]
        public string FailDesc { get; set; }

        [Required]
        [Display(Name = "Комплект документов (ТД, КД)")]
        public string TDKD { get; set; }

        [Required]
        [Display(Name = "Проверяемое подразделение")]
        public int SubunitId { get; set; }

        [Required]
        [Display(Name = "Проверяемый участок")]
        public int SectorId { get; set; }

        [Required]
        [Display(Name = "Обнаружено несоответствие")]
        public bool isFail { get; set; }

        public SelectList Subunits { get; set; }

        public List<Sector> Sectors { get; set; }

        public CreateCheckViewModel() { }

        public CreateCheckViewModel(journalContext context)
        {
            FillLists(context);
        }

        public void FillLists(journalContext context)
        {
            Subunits = new SelectList(context.Subunits.ToList(), "Id", "Name");
            Sectors = context.Sectors.ToList();
        }
    }
}
