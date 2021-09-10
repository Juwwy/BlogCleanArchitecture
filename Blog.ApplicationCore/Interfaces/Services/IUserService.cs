using Blog.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        Task<ApplicationUserDTO> GetUser(ClaimsPrincipal principal);
        Task<string> GetUserId(ClaimsPrincipal principal);
        Task<IEnumerable<ApplicationUserDTO>> GetUsers();
        Task AddUser(AddApplicationUserDTO user);
        Task LoginUser(LoginDTO model);
        Task LogoutUser();
    }
}
