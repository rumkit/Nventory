using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventory.Models
{
    public class IdentityUserRepository : IUsersRepository
    {
        readonly UserManager<NventoryUser> _userManager;
        readonly RoleManager<NventoryRole> _roleManager;
        readonly ApplicationDbContext _context;

        public IdentityUserRepository(UserManager<NventoryUser> userManager, RoleManager<NventoryRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<Result> CreateUserAsync(UserViewModel user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            var newUser = user.ToIdentityUser();
            var result  = await _userManager.CreateAsync(newUser, user.Password).ConfigureAwait(false);
            return new Result(result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<Result> DeleteUserAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentException(nameof(id));
            var userToDelete = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if(userToDelete == null)
                throw new NullReferenceException("unable to find user with given id");
            var result = await _userManager.DeleteAsync(userToDelete).ConfigureAwait(false);
            return new Result(result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<UserViewModel> GetUserAsync(string id)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);                        
            return identityUser == null ? null : new UserViewModel(identityUser);
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

        public async Task<Result> UpdateUserAsync(UserViewModel user)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            identityUser.Name = user.Name;
            identityUser.Surname = user.Surname;
            identityUser.Patronymic = user.Patronymic;
            identityUser.StaffNumber = user.StaffNumber;
            identityUser.Email = user.Email;
            var result = await _userManager.UpdateAsync(identityUser);                        
            return new Result(result.Succeeded);
        }
    }
}
