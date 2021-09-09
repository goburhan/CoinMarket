using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.ApplicationLogic
{
    public interface IApplicationUsersUseCases
    {
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user);
        Task<ApplicationUser> ViewUserByIdAsync(int id);
        Task<IEnumerable<ApplicationUser>> ViewUsersAsync();
    }
}