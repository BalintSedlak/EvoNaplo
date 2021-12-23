using EvoNaplo.Common.Models;
using System;

namespace EvoNaplo.Common.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserDTO()
        {
            Id = -1;
        }
    }
}
