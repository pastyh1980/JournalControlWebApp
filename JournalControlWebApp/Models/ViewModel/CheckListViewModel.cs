using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JournalControlWebApp.Models.dbo;
using JournalControlWebApp.Models.FSPViewModel;

namespace JournalControlWebApp.Models.ViewModel
{
    public class CheckListViewModel
    {
        public List<Check> Checks { get; set; }
        public FilterCheckViewModel FilterViewModel { get; set; }
        public SortCheckViewModel SortViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
