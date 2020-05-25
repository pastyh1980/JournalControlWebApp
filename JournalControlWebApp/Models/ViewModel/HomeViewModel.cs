using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalControlWebApp.Models.ViewModel
{
    public class HomeViewModel
    {
        public string FIO { get; set; }
        public string Post { get; set; }
        public string Subunit { get; set; }
        public string Sector { get; set; }
        public IList<string> UserRoles { get; set; }

    }
}
