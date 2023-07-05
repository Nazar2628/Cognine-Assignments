﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using StudentProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Utilities
{
    public class DbIntializer : IDbIntializer
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbIntializer(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public DbIntializer(
            RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        public void Intialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;

            }
            if (!_roleManager.RoleExistsAsync(WebsiteRole.Website_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Website_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Website_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Website_Student)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRole.Website_Teacher)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"

                }, "Admin@123").GetAwaiter().GetResult();
                var appuser = _userManager.Users.Where(x => x.Email == "admin@gmail.com").FirstOrDefault();
                if(appuser != null)
                {
                    _userManager.AddToRoleAsync(appuser,WebsiteRole.Website_Admin).GetAwaiter().GetResult();
                }

            }
        }
    }
}
