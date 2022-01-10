using EvoNaplo.Common.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EvoNaplo.Domains.Users.Models
{
    /// <summary>
    /// This class is used to represent a database entry in the users table
    /// </summary>
    public class UserViewModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleType Role { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(UserViewModel user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = user.Role;
        }
    }
}
