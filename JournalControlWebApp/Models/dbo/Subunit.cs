using System;
using System.Collections.Generic;

namespace JournalControlWebApp.Models.dbo
{
    public partial class Subunit
    {
        public Subunit()
        {
            Sectors = new HashSet<Sector>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
