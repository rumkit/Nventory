using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventory.Models
{
    public class IdentityUserRepository : IUsersRepository
    {
        UserManager<NventoryUser> _userManager;
        RoleManager<NventoryRole> _roleManager;

        public IdentityUserRepository(UserManager<NventoryUser> userManager, RoleManager<NventoryRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result> CreateUserAsync(UserViewModel user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            var newUser = user.ToIdentityUser();
            var result  = await _userManager.CreateAsync(newUser, user.Password).ConfigureAwait(false);
            return new Result(result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var identityUsers = await _userManager.Users.ToListAsync();
            var userModels = new List<UserViewModel>();
            foreach (var user in identityUsers)
            {
                var userModel = new UserViewModel(user)
                {
                    IsAdmin = await _userManager.IsInRoleAsync(user, "Admin")
                };
                userModels.Add(userModel);
            }
            return userModels;
        }
    }
}
