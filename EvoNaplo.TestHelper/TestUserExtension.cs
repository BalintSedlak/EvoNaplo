using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.Helpers;

namespace EvoNaplo.TestHelper
{
    public static class TestUserExtension
    {
        public static UserViewModel ConvertUserToUserViewModel(this UserHelper userHelper, User user)
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
