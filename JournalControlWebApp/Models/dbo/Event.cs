using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Event
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int Developer { get; set; }
        public int? ReportWorker { get; set; }
        public int? DeleteWorker { get; set; }
        [Display(Name = "Причина несоответствия")]
        public string FailReason { get; set; }
        [Display(Name = "Описание мероприятия")]
        public string Description { get; set; }
        [Display(Name = "Ответственный")]
        public string ResponsWorker { get; set; }
        [Display(Name = "Срок исполнения")]
        public DateTime DueDate { get; set; }
        [Display(Name = "Дата разработки")]
        public DateTime DevelopDate { get; set; }
        [Display(Name = "Отчет")]
        public string Report { get; set; }
        [Display(Name = "Подтверждающая информация")]
        public string ProofInf { get; set; }
        [Display(Name = "Дата отчета")]
        public DateTime? ReportDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
        [Display(Name = "Дата удаления")]
        public DateTime? DeleteDate { get; set; }

        public virtual Check Check { get; set; }
        [Display(Name = "ФИО удалившего")]
        public virtual Worker DeleteWorkerNavigation { get; set; }
        [Display(Name = "Разработчик")]
        public virtual Worker DeveloperNavigation { get; set; }
        [Display(Name = "ФИО предоставившего отчет")]
        public virtual Worker ReportWorkerNavigation { get; set; }
    }
}
