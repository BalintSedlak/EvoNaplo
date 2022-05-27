using EvoNaplo.Infrastructure.DataAccess.Entities;

namespace EvoNaplo.Infrastructure.Models.DTO
{
    public class UserAuth
    {
        public UserAuth(UserEntity user)
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
