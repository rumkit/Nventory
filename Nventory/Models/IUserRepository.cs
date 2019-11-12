using Nventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventory.Models
{
    public interface IUsersRepository
    {       
        Task<IEnumerable<INventoryUser>> GetUsersAsync();
        Task<INventoryUser> GetUserAsync(string id);
        Task<Result> CreateUserAsync(INventoryUser user, string password);
        Task<Result> DeleteUserAsync(string id);

        Task<Result> UpdateUserAsync(INventoryUser user, IList<string> selectedRoles = null);

        Task<IEnumerable<INventoryRole>> GetAvailableRolesAsync();

    }
}
