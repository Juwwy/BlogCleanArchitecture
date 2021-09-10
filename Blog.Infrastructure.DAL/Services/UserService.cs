using Blog.ApplicationCore.DTOs;
using Blog.ApplicationCore.Entities;
using Blog.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.DAL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }


        public async Task AddUser(AddApplicationUserDTO user)
        {
            var appUser = new ApplicationUser
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                UserName = user.Email,
                UserImgUrl = user.UserImgUrl
            };

            var result = await userManager.CreateAsync(appUser, user.Password);

            if(result.Succeeded)
            {
                if(!await roleManager.RoleExistsAsync(user.UserRole))
                {
                    //This will create once
                    await roleManager.CreateAsync(new IdentityRole { Name = user.UserRole });
                }

                await userManager.AddToRoleAsync(appUser, user.UserRole);
            }
        }

        public async Task<ApplicationUserDTO> GetUser(ClaimsPrincipal principal)
        {
            var appUser = await userManager.GetUserAsync(principal);
            return new ApplicationUserDTO
            {
                Id = appUser.Id,
                Firstname = appUser.Firstname,
                Lastname = appUser.Lastname,
                Email = appUser.Email,
                UserImgUrl = appUser.UserImgUrl,
                UserRole = appUser.UserRole,
                DateCreated = appUser.DateCreated.ToString("D")
            };
        }

        public async Task<string> GetUserId(ClaimsPrincipal principal)
        {
            var appUser = await GetUser(principal);
            return appUser.Id;
        }

        public Task<IEnumerable<ApplicationUserDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task LoginUser(LoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task LogoutUser()
        {
            throw new NotImplementedException();
        }
    }
}
