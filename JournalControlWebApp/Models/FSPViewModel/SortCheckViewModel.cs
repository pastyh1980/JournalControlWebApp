using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalControlWebApp.Models.FSPViewModel
{
    public enum SortStateCheck
    {
        FailCountAsc,
        FailCountDesc,
        CheckSubunitAsc,
        CheckSubunitDesc,
        SectorAsc,
        SectorDesc,
        CheckDateAsc,
        CheckDateDesc,
        RegWorkerAsc,
        RegWorkerDesc,
        ControlIndicatorAsc,
        ControlIndicatorDesc,
        FailDescriptionAsc,
        FailDescriptionDesc,
        RegSubunitAsc,
        RegSubunitDesc,
        DeleteReasonAsc,
        DeleteReasonDesc
    }

    public class SortCheckViewModel
    {
        public SortStateCheck FailCountSort { get; private set; }
        public SortStateCheck CheckSubunitSort { get; private set; }
        public SortStateCheck SectorSort { get; private set; }
        public SortStateCheck CheckDateSort { get; private set; }
        public SortStateCheck RegWorkerSort { get; private set; }
        public SortStateCheck ControlIndicatorSort { get; private set; }
        public SortStateCheck FailDescriptionSort { get; private set; }
        public SortStateCheck RegSubunitSort { get; private set; }
        public SortStateCheck DeleteReasonSort { get; private set; }
        public SortStateCheck Current { get; private set; }

        public SortCheckViewModel(SortStateCheck sortOrder)
        {
            FailCountSort = sortOrder == SortStateCheck.FailCountAsc ? SortStateCheck.FailCountDesc : SortStateCheck.FailCountAsc;
            CheckSubunitSort = sortOrder == SortStateCheck.CheckSubunitAsc ? SortStateCheck.CheckSubunitDesc : SortStateCheck.CheckSubunitAsc;
            SectorSort = sortOrder == SortStateCheck.SectorAsc ? SortStateCheck.SectorDesc : SortStateCheck.SectorAsc;
            CheckDateSort = sortOrder == SortStateCheck.CheckDateAsc ? SortStateCheck.CheckDateDesc : SortStateCheck.CheckDateAsc;
            RegWorkerSort = sortOrder == SortStateCheck.RegWorkerAsc ? SortStateCheck.RegWorkerDesc : SortStateCheck.RegWorkerAsc;
            ControlIndicatorSort = sortOrder == SortStateCheck.ControlIndicatorAsc ? SortStateCheck.ControlIndicatorDesc : SortStateCheck.ControlIndicatorAsc;
            FailDescriptionSort = sortOrder == SortStateCheck.FailDescriptionAsc ? SortStateCheck.FailDescriptionDesc : SortStateCheck.FailDescriptionAsc;
            RegSubunitSort = sortOrder == SortStateCheck.RegSubunitAsc ? SortStateCheck.RegSubunitDesc : SortStateCheck.RegSubunitAsc;
            DeleteReasonSort = sortOrder == SortStateCheck.DeleteReasonAsc ? SortStateCheck.DeleteReasonDesc : SortStateCheck.DeleteReasonAsc;

            Current = sortOrder;
        }
    }
}
