namespace EvoNaploTFS.Models.DTO
{
    public class SessionDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }

        public SessionDTO(User user)
        {
            id = user.Id;
            name = $"{user.FirstName} {user.LastName}";
            switch (user.Role)
            {
                case User.RoleTypes.Student:
                    role = "Student";
                    break;
                case User.RoleTypes.Mentor:
                    role = "Mentor";
                    break;
                case User.RoleTypes.Admin:
                    role = "Admin";
                    break;
                case User.RoleTypes.Jani:
                    role = "Jani";
                    break;
                default:
                    break;
            }
        }
    }
}
