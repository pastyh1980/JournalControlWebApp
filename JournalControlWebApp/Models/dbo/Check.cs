using System;
using System.Collections.Generic;

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
        public DateTime RegDate { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckWorker { get; set; }
        public string TdKd { get; set; }
        public string ControlIndicator { get; set; }
        public int CountOperations { get; set; }
        public string FailCount { get; set; }
        public string FailDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsFail { get; set; }

        public virtual Worker DeleteWorkerNavigation { get; set; }
        public virtual Worker RegWorkerNavigation { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
