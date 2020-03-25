using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp.Models.FSPViewModel
{
    public class FilterCheckViewModel
    {
        public string QueryString { get; private set; }
        public SelectList Subunits { get; private set; }
        public int? SelectedSubunit { get; private set; }
        public List<Sector> Sectors { get; private set; }
        public int? SelectedSector { get; private set; }

        public int? SelectedDeleteReason { get; private set; }
        public SelectList DeleteReasonList { get; private set; }

        public FilterCheckViewModel(List<Subunit> subunits, List<Sector> sectors, int? selectedSubunit, int? selectedSector, string query, int? selectedDeleteReason = 0)
        {
            QueryString = query;
            sectors.Insert(0, new Sector { Id = 0, SectorName = "Все" });
            Sectors = sectors;
            SelectedSubunit = selectedSubunit;
            SelectedSector = selectedSector;
            subunits.Insert(0, new Subunit { Id = 0, Name = "Все" });
            Subunits = new SelectList(subunits, "Id", "Name", selectedSubunit);

            List<DeleteReasonItem> items = new List<DeleteReasonItem>
            {
                new DeleteReasonItem(0, "Все"),
                new DeleteReasonItem(1, "-"),
                new DeleteReasonItem(2, "Устанение"),
                new DeleteReasonItem(3, "Ошибка")
            };

            SelectedDeleteReason = selectedDeleteReason;
            DeleteReasonList = new SelectList(items, "Id", "Value", selectedDeleteReason);
        }

        private class DeleteReasonItem
        {
            public int Id { get; set; }
            public string Value { get; set; }

            public DeleteReasonItem(int id, string value)
            {
                Id = id;
                Value = value;
            }
        }
    }
}
