using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> CreateAsync(ApplicationUser user);
        Task DeleteAsync(int id);
        Task<IEnumerable<ApplicationUser>> GetAsync();
        Task<ApplicationUser> GetByIdAsync(int id);
        Task UpdateAsync(ApplicationUser user);
    }
}