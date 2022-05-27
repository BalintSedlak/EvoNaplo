using EvoNaplo.Infrastructure.Models.Entities;
using System;

namespace EvoNaplo.Infrastructure.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }

        public UserDTO()
        {
            Id = -1;
        }
    }
}
