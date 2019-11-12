using System.Collections.Generic;

namespace Nventory.Models
{
    public interface INventoryUser
    {
        string Email { get; set; }
        string Id { get; set; }        
        string Name { get; set; }        
        string Patronymic { get; set; }        
        string StaffNumber { get; set; }
        string Surname { get; set; }
        string UserName { get; set; }      
        IList<INventoryRole> Roles { get;set;}
    }
}