using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using JournalControlWebApp.Models.dbo;
using JournalControlWebApp.Models.FSPViewModel;

namespace JournalControlWebApp.Models.ViewModel
{
    public class CreateEventViewModel
    {
        public List<Check> Checks { get; set; }
        public FilterCheckViewModel FilterViewModel { get; set; }
        public SortCheckViewModel SortViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }

        [Required]
        public int? SelectedCheckId { get; set; }

        [Required]
        [Display(Name = "Причина несоответствия")]
        public string FailReason { get; set; }

        [Required]
        [Display(Name = "Описание мероприятия")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Ответственный")]
        public string ResponseWorker { get; set; }

        [Required]
        [Display(Name = "Срок исполнения")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}
