using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.DTO;

namespace EvoNaplo.Infrastructure.Helpers
{
    //TODO: Replace this with property mapper
    public class UserHelper
    {
        public UserDTO ConvertUserToUserDTO(UserEntity user)
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

        public UserEntity ConvertUserViewModelToUser(UserViewModel user)
        {
            return new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email,
                PhoneNumber = !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : "No data",
                Role = user.Role
            };
        }
    }
}