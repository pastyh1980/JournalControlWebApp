using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Check
    {
        public Check()
        {
            Events = new HashSet<Event>();
            Shows = new HashSet<Show>();
        }

        public int Id { get; set; }
        public int RegWorker { get; set; }
        public int? DeleteWorker { get; set; }
        public int SectorId { get; set; }
        [Display(Name = "Дата регистрации")]
        public DateTime RegDate { get; set; }
        [Display(Name = "Дата проверки")]
        public DateTime CheckDate { get; set; }
        public string CheckWorker { get; set; }
        [Display(Name = "Комплект ТД/КД")]
        public string TdKd { get; set; }
        [Display(Name = "Объект контроля")]
        public string ControlIndicator { get; set; }
        public int CountOperations { get; set; }
        [Display(Name = "Номер несоответствия")]
        public string FailCount { get; set; }

        [Display(Name = "Описание несоответствия")]
        public string FailDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
        [Display(Name = "Дата удаления")]
        public DateTime? DeleteDate { get; set; }
        public bool IsFail { get; set; }

        [Display(Name = "ФИО удалившего")]
        public virtual Worker DeleteWorkerNavigation { get; set; }
        [Display(Name = "ФИО проверяющего")]
        public virtual Worker RegWorkerNavigation { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
