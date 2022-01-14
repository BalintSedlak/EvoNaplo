using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.Infrastructure.DataAccess.Entities;

namespace EvoNaplo.TestHelper
{
    public static class TestUserExtension
    {
        public static UserViewModel ConvertUserToUserViewModel(this UserHelper userHelper, UserEntity user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
