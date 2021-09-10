using Blog.ApplicationCore.Entities;
using Blog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.DAL.DBContext
{
    public static class SeedData
    {
        public async static Task AddUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           if(await userManager.FindByEmailAsync("Juwonolowu52@gmail.com") == null)
            {
                var appUser = new ApplicationUser
                {
                    Firstname = "Oluwajuwon",
                    Lastname = "Olowu",
                    Email = "Juwonolowu52@gmail.com",
                    UserImgUrl = "",
                    UserName = "Juwonolowu52@gmail.com"
                };

                var result = await userManager.CreateAsync(appUser, "BossJuwwy123@");

                if (result.Succeeded)
                {
                    await CreateRoles(roleManager);

                    await userManager.AddToRoleAsync(appUser, "Administrator");
                }
            }
        }

        private async static Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Moderator" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Editor" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Reader" });

            }
        }

        public async static Task AddCategories(BlogDbContext dbContext)
        {
           if(!dbContext.Categories.Any())
            {
                var Categories = new List<Category>()
            {
                new Category{ Name = "Sport" },
                new Category{ Name = "Politics" },
                new Category{ Name = "Local News" },
                new Category{ Name = "Foreign News" },
                new Category{ Name = "Entertainment" },

            };

                await dbContext.Categories.AddRangeAsync(Categories);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
