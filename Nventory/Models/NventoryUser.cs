using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nventory.Models
{
    public class NventoryUser : IdentityUser, INventoryUser
    {
        public string Name {get;set; }
        public string Surname { get;set;}
        public string Patronymic { get;set;}
        public string StaffNumber { get;set;}
        [NotMapped]
        public IList<INventoryRole> Roles { get;set;}


    }
}