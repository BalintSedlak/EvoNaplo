using EvoNaplo.Common.Models.DTO;

namespace EvoNaplo.UserDomain.Models
{
    //TODO: Replace this with property mapper
    internal static class UserHelper
    {
        public static UserDTO ConvertUserToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : "No data"
            };
        }
    }
}