using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nventory.Data;
using Nventory.ViewModels;
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

        public async Task<Result> CreateUserAsync(INventoryUser user, string password)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            var newUser = new NventoryUser()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                StaffNumber = user.StaffNumber
            };
            var result  = await _userManager.CreateAsync(newUser, password).ConfigureAwait(false);
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

        public async Task<INventoryUser> GetUserAsync(string id)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);                        
            return identityUser == null ? null : new UserViewModel(identityUser) { Roles = await GetUserRoles(identityUser)};
        }

        public async Task<IEnumerable<INventoryUser>> GetUsersAsync()
        {
            var identityUsers = await _userManager.Users.ToListAsync();
            var userModels = new List<UserViewModel>();
            foreach (var user in identityUsers)
            {
                var userModel = new UserViewModel(user)
                {
                    Roles = await GetUserRoles(user)
                };
                userModels.Add(userModel);
            }
            return userModels;
        }

        private async Task<IList<INventoryRole>> GetUserRoles(NventoryUser user)
        {
            return (await _userManager.GetRolesAsync(user))
                    .Select(rolename => _roleManager.Roles.First(r => r.Name == rolename))
                    .ToList<INventoryRole>();
        }

        public async Task<Result> UpdateUserAsync(INventoryUser user, IList<string> selectedRoles = null)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            identityUser.Name = user.Name;
            identityUser.Surname = user.Surname;
            identityUser.Patronymic = user.Patronymic;
            identityUser.StaffNumber = user.StaffNumber;
            identityUser.Email = user.Email;
            var result = await _userManager.UpdateAsync(identityUser);
            if(selectedRoles != null)
                await UpdateRoles(user.Id,selectedRoles);
            return new Result(result.Succeeded);
        }

        private async Task UpdateRoles(string userId, IList<string> selectedRoles)
        {
            var user = _userManager.Users.First(u => u.Id == userId);
            var currentRoles = await _userManager.GetRolesAsync(user);
            var rolesToRemove = currentRoles.Except(selectedRoles).ToArray();
            var rolesToAdd = selectedRoles.Except(currentRoles).ToArray();
            if(rolesToRemove.Length > 0)
                await _userManager.RemoveFromRolesAsync(user,rolesToRemove);
            if(rolesToAdd.Length > 0)
                await _userManager.AddToRolesAsync(user,rolesToAdd);
            return;

        }

        public async Task<IEnumerable<INventoryRole>> GetAvailableRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync<INventoryRole>();
        }
    }
}
