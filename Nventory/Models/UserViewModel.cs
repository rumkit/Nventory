using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nventory.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public UserViewModel(NventoryUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            Patronymic = user.Patronymic;
            StaffNumber = user.StaffNumber;
        }

        public NventoryUser ToIdentityUser()
        {
            return new NventoryUser ()
            {
                Id = this.Id,
                UserName = this.UserName,
                Email = this.Email,
                Name = this.Name,
                Surname = this.Surname,
                Patronymic = this.Patronymic,
                StaffNumber = this.StaffNumber
            };

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
        public bool IsAdmin { get; set; }
    }
}