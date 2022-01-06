﻿using EvoNaplo.Common.Models.Entities;

namespace EvoNaplo.UserDomain.Models
{
    internal class UserAuth
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
