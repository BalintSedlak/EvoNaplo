using EvoNaplo.Common.Models;

namespace EvoNaplo.Common.Models.DTO
{
    public class SessionDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }

        //TODO
        //public SessionDTO(User user)
        //{
        //    id = user.Id;
        //    name = $"{user.FirstName} {user.LastName}";
        //    switch (user.Role)
        //    {
        //        case RoleType.Student:
        //            role = "Student";
        //            break;
        //        case RoleType.Mentor:
        //            role = "Mentor";
        //            break;
        //        case RoleType.Admin:
        //            role = "Admin";
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
