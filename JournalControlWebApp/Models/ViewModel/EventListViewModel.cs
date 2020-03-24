using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JournalControlWebApp.Models.FSPViewModel;
using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp.Models.ViewModel
{
    public class EventListViewModel
    {
        public FilterEventViewModel FilterViewModel { get; set; }

        public SortEventViewModel SortViewModel { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<Event> Events { get; set; }
    }
}
