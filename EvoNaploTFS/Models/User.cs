using System.ComponentModel.DataAnnotations;

namespace EvoNaploTFS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public RoleTypes Role { get; set; }

        public enum RoleTypes
        {
            Student,
            Mentor,
            Admin,
            Jani
        }
        public User()
        {

        }

        public User(User user)
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
