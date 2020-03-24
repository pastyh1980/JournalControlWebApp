using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp.Models.FSPViewModel
{
    public class FilterEventViewModel
    {
        public string QueryString { get; private set; }
        public SelectList Subunits { get; private set; }
        public int? SelectedSubunit { get; private set; }
        public List<Sector> Sectors { get; private set; }
        public int? SelectedSector { get; private set; }

        public FilterEventViewModel(List<Subunit> subunits, List<Sector> sectors, int? selectedSubunit, int? selectedSector, string query)
        {
            QueryString = query;
            sectors.Insert(0, new Sector { Id = 0, SectorName = "Все" });
            Sectors = sectors;
            SelectedSubunit = selectedSubunit;
            SelectedSector = selectedSector;
            subunits.Insert(0, new Subunit { Id = 0, Name = "Все" });
            Subunits = new SelectList(subunits, "Id", "Name", selectedSubunit);
        }

    }
}
