using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.ApplicationCore.Domains.Users.Models;

namespace EvoNaplo.Infrastructure.Models.DTO
{
    public class SessionDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }

        public SessionDTO(UserDTO user)
        {
            id = user.Id;
            name = $"{user.Name}";
            switch (user.Role)
            {
                case RoleType.Student:
                    role = "Student";
                    break;
                case RoleType.Mentor:
                    role = "Mentor";
                    break;
                case RoleType.Admin:
                    role = "Admin";
                    break;
                default:
                    break;
            }
        }
    }
}
