using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventory.Models
{
    public interface IUsersRepository
    {       
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserAsync(string id);
        Task<Result> CreateUserAsync(UserViewModel user);
        Task<Result> DeleteUserAsync(string id);

        Task<Result> UpdateUserAsync(UserViewModel user);

    }
}
