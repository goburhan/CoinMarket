using App.Repository.ApiClient;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ICoinMarketAppExecuter coinMarketAppExecuter;
        public ApplicationUserRepository(ICoinMarketAppExecuter coinMarketAppExecuter)
        {
            this.coinMarketAppExecuter = coinMarketAppExecuter;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAsync()
        {
            return await coinMarketAppExecuter.InvokeGet<IEnumerable<ApplicationUser>>("api/applicationusers");
        }

        public async Task<ApplicationUser> GetByIdAsync(int id)
        {
            return await coinMarketAppExecuter.InvokeGet<ApplicationUser>($"api/applicationusers/{id}");
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user)
        {
            return await coinMarketAppExecuter.InvokePost("api/applicationusers", user);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            await coinMarketAppExecuter.InvokePut($"api/applicationusers/{user.Id}", user);
        }

        public async Task DeleteAsync(int id)
        {
            await coinMarketAppExecuter.InvokeDelete($"api/applicationusers/{id}");
        }
    }
}
