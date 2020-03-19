using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Worker : IdentityUser
    {
        public Worker()
        {
            CheckDeleteWorkerNavigation = new HashSet<Check>();
            CheckRegWorkerNavigation = new HashSet<Check>();
            EventsDeleteWorkerNavigation = new HashSet<Event>();
            EventsDeveloperNavigation = new HashSet<Event>();
            EventsReportWorkerNavigation = new HashSet<Event>();
            Shows = new HashSet<Show>();
        }

        public int SectorId { get; set; }
        public string Login { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public string Otch { get; set; }
        public string Post { get; set; }
        public string Access { get; set; }
        public string Passwd { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual ICollection<Check> CheckDeleteWorkerNavigation { get; set; }
        public virtual ICollection<Check> CheckRegWorkerNavigation { get; set; }
        public virtual ICollection<Event> EventsDeleteWorkerNavigation { get; set; }
        public virtual ICollection<Event> EventsDeveloperNavigation { get; set; }
        public virtual ICollection<Event> EventsReportWorkerNavigation { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
