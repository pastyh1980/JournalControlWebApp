using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JournalControlWebApp.Models.dbo;
using JournalControlWebApp.Models.FSPViewModel;

namespace JournalControlWebApp.Models.ViewModel
{
    public class WorkerListViewModel
    {
        public IEnumerable<Worker> Workers { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortWorkerViewModel SortViewModel { get; set; }

        public FilterWorkerViewModel FilterViewModel { get; set; }
    }
}
