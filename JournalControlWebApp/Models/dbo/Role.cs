using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JournalControlWebApp.Models.dbo
{
    public class Role : IdentityRole<int>
    {
        public Role(string roleName) : base(roleName)
        { }

        public Role() : base()
        { }
    }
}
