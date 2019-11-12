using Microsoft.AspNetCore.Mvc.Rendering;
using Nventory.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nventory.ViewModels
{
    public class UserViewModel : INventoryUser
    {
        public UserViewModel()
        {

        }

        public UserViewModel(INventoryUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            Patronymic = user.Patronymic;
            StaffNumber = user.StaffNumber;
            Roles = user.Roles;
        }      

        public string Id { get; set; }
        [Required]
        [DisplayName("Login")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Patronymic")]
        public string Patronymic { get; set; }
        [DisplayName("Staff id")]
        public string StaffNumber { get; set; }
        [DisplayName("Administrator")]
        public bool IsAdmin => Roles?.Any(role => role.Name == "Admin") ?? false;

        public IList<INventoryRole> Roles { get; set; }

        public IList<string> SelectedRoles { get;set;}
        public IList<SelectListItem> AvailableRoles { get;set;}
    }
}