using MyApp.Repository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class ApplicationUsersUseCases
    {
        private readonly IApplicationUserRepository _userRepository;

        public ApplicationUsersUseCases(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IEnumerable<ApplicationUser>> ViewUsersAsync()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<ApplicationUser> ViewUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user)
        {
            return await _userRepository.CreateAsync(user);
        }
    }
}
