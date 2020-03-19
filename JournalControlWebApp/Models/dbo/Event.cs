using System;
using System.Collections.Generic;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Event
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int Developer { get; set; }
        public int? ReportWorker { get; set; }
        public int? DeleteWorker { get; set; }
        public string FailReason { get; set; }
        public string Description { get; set; }
        public string ResponsWorker { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DevelopDate { get; set; }
        public string Report { get; set; }
        public string ProofInf { get; set; }
        public DateTime? ReportDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual Check Check { get; set; }
        public virtual Worker DeleteWorkerNavigation { get; set; }
        public virtual Worker DeveloperNavigation { get; set; }
        public virtual Worker ReportWorkerNavigation { get; set; }
    }
}
