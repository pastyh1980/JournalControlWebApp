﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using JournalControlWebApp.Models.dbo;

namespace JournalControlWebApp
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<Worker> userManager, RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role("ADMIN"));
                await roleManager.CreateAsync(new Role("CHECK_DETAIL"));
                await roleManager.CreateAsync(new Role("EVENT_DETAIL"));
                await roleManager.CreateAsync(new Role("SUBSHOW"));
                await roleManager.CreateAsync(new Role("DEVEL"));
                await roleManager.CreateAsync(new Role("REPORT"));
                await roleManager.CreateAsync(new Role("REPORT_SHOW"));
                await roleManager.CreateAsync(new Role("CONTROL"));
                await roleManager.CreateAsync(new Role("REG"));

            }
        }
    }
}
