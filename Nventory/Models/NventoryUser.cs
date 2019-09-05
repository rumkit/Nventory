using Microsoft.AspNetCore.Identity;

namespace Nventory.Models
{
    public class NventoryUser : IdentityUser
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public string StaffNumber;

    }
}