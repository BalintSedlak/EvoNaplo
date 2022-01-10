using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.Entities;

namespace EvoNaplo.Domains.Users.Models
{
    //TODO: Replace this with property mapper
    public class UserHelper
    {
        public UserDTO ConvertUserToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : "No data",
                Role = user.Role
            };
        }

        public User ConvertUserViewModelToUser(UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : "No data",
                Role = user.Role
            };
        }
    }
}