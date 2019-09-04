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

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var identityUsers = await _userManager.Users.ToListAsync();
            var userModels = new List<UserModel>();
            foreach(var user in identityUsers)
            {
                var userModel = new UserModel()
                {
                    Name = user.UserName,
                    Email = user.Email,
                    IsAdmin = await _userManager.IsInRoleAsync(user,"Admin")
                };
                userModels.Add(userModel);
            }
            return userModels;
        }        
    }
}
