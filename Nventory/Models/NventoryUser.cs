using Microsoft.AspNetCore.Identity;

namespace Nventory.Models
{
    public class NventoryUser : IdentityUser
    {
        public string Name {get;set; }
        public string Surname { get;set;}
        public string Patronymic { get;set;}
        public string StaffNumber { get;set;}

    }
}