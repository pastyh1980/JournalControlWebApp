using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp.Models.FSPViewModel
{
    public class FilterWorkerViewModel
    {
        public string QueryString { get; set; }

        public FilterWorkerViewModel(string query)
        {
            QueryString = query;
        }
    }
}
