using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventory.Models
{
    public interface IUsersRepository
    {        
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<Result> CreateUserAsync(UserViewModel user);
    }
}
