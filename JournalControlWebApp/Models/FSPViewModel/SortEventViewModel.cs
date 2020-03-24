using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalControlWebApp.Models.FSPViewModel
{

    public enum SortStateEvent
    {
        FailCountAsc,
        FailCountDesc,
        CheckSubunitAsc,
        CheckSubunitDesc,
        CheckSectorAsc,
        CheckSectorDesc,
        FailDescriptionAsc,
        FailDescriptionDesc,
        EventDescriptionAsc,
        EventDescriptionDesc,
        ResponseWorkerAsc,
        ResponseWorkerDesc,
        DueDateAsc,
        DueDateDesc,
        DeveloperSubunitAsc,
        DeveloperSubunitDesc,
        DeveloperAsc,
        DeveloperDesc,
        ReportAsc,
        ReportDesc
    }

    public class SortEventViewModel
    {
        public SortStateEvent FailCountSort { get; private set; }
        public SortStateEvent CheckSubunitSort { get; private set; }
        public SortStateEvent CheckSectorSort { get; private set; }
        public SortStateEvent FailDescriptionSort { get; private set; }
        public SortStateEvent EventDescriptionSort { get; private set; }
        public SortStateEvent ResponseWorkerSort { get; private set; }
        public SortStateEvent DueDateSort { get; private set; }
        public SortStateEvent DeveloperSubunitSort { get; private set; }
        public SortStateEvent DeveloperSort { get; private set; }
        public SortStateEvent ReportSort { get; private set; }

        public SortStateEvent Current { get; private set; }

        public SortEventViewModel(SortStateEvent sortOrder)
        {
            FailCountSort = sortOrder == SortStateEvent.FailCountAsc ? SortStateEvent.FailCountDesc : SortStateEvent.FailCountAsc;
            CheckSubunitSort = sortOrder == SortStateEvent.CheckSubunitAsc ? SortStateEvent.CheckSubunitDesc : SortStateEvent.CheckSubunitAsc;
            CheckSectorSort = sortOrder == SortStateEvent.CheckSectorAsc ? SortStateEvent.CheckSectorDesc : SortStateEvent.CheckSectorAsc;
            FailDescriptionSort = sortOrder == SortStateEvent.FailDescriptionAsc ? SortStateEvent.FailDescriptionDesc : SortStateEvent.FailDescriptionAsc;
            EventDescriptionSort = sortOrder == SortStateEvent.EventDescriptionAsc ? SortStateEvent.EventDescriptionDesc : SortStateEvent.EventDescriptionAsc;
            ResponseWorkerSort = sortOrder == SortStateEvent.ResponseWorkerAsc ? SortStateEvent.ResponseWorkerDesc : SortStateEvent.ResponseWorkerAsc;
            DueDateSort = sortOrder == SortStateEvent.DueDateAsc ? SortStateEvent.DueDateDesc : SortStateEvent.DueDateAsc;
            DeveloperSubunitSort = sortOrder == SortStateEvent.DeveloperSubunitAsc ? SortStateEvent.DeveloperSubunitDesc : SortStateEvent.DeveloperSubunitAsc;
            DeveloperSort = sortOrder == SortStateEvent.DeveloperAsc ? SortStateEvent.DeveloperDesc : SortStateEvent.DeveloperAsc;
            ReportSort = sortOrder == SortStateEvent.ReportAsc ? SortStateEvent.ReportDesc : SortStateEvent.ReportAsc;

            Current = sortOrder;
        }
    }
}
