using System;
using System.Collections.Generic;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Sector
    {
        public Sector()
        {
            Check = new HashSet<Check>();
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public int SubunitId { get; set; }
        public string SectorName { get; set; }
        public bool IsMain { get; set; }

        public virtual Subunit Subunit { get; set; }
        public virtual ICollection<Check> Check { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
