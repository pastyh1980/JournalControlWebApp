using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalControlWebApp.Models.FSPViewModel
{
    public enum SortStateWorker
    {
        LoginAsc,
        LoginDesc,
        NameAsc,
        NameDesc,
        FamilyAsc,
        FamilyDesc,
        OtchAsc,
        OtchDesc,
        PostAsc,
        PostDesc,
        SubunitAsc,
        SubunitDesc,
        SectorAsc,
        SectorDesc
    }

    public class SortWorkerViewModel
    {
        public SortStateWorker LoginSort { get; private set; }
        public SortStateWorker FamilySort { get; private set; }
        public SortStateWorker NameSort { get; private set; }
        public SortStateWorker OtchSort { get; private set; }
        public SortStateWorker PostSort { get; private set; }
        public SortStateWorker SubunitSort { get; private set; }
        public SortStateWorker SectorSort { get; private set; }
        public SortStateWorker Current { get; private set; }

        public SortWorkerViewModel(SortStateWorker sortOrder)
        {
            LoginSort = sortOrder == SortStateWorker.LoginAsc ? SortStateWorker.LoginDesc : SortStateWorker.LoginAsc;
            FamilySort = sortOrder == SortStateWorker.FamilyAsc ? SortStateWorker.FamilyDesc : SortStateWorker.FamilyAsc;
            NameSort = sortOrder == SortStateWorker.NameAsc ? SortStateWorker.NameDesc : SortStateWorker.NameAsc;
            OtchSort = sortOrder == SortStateWorker.OtchAsc ? SortStateWorker.OtchDesc : SortStateWorker.OtchAsc;
            PostSort = sortOrder == SortStateWorker.PostAsc ? SortStateWorker.PostDesc : SortStateWorker.PostAsc;
            SubunitSort = sortOrder == SortStateWorker.SubunitAsc ? SortStateWorker.SubunitDesc : SortStateWorker.SubunitAsc;
            SectorSort = sortOrder == SortStateWorker.SectorAsc ? SortStateWorker.SectorDesc : SortStateWorker.SectorAsc;

            Current = sortOrder;
        }
    }
}
