using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EvoNaplo.ApplicationCore.Domains.Users.Models
{
    public class UserViewModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }

        public UserViewModel() {}

        public UserViewModel(UserViewModel user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Email = user.Email;
            Role = user.Role;
        }
    }
}
