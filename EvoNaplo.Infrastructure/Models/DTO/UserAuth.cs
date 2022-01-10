using EvoNaplo.Infrastructure.Models.Entities;

namespace EvoNaplo.Infrastructure.Models.DTO
{
    public class UserAuth
    {
        public UserAuth(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
