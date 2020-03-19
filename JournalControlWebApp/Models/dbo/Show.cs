using System;
using System.Collections.Generic;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Show
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public DateTime Date { get; set; }
        public int WorkerId { get; set; }

        public virtual Check Check { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
