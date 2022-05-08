﻿using System.ComponentModel.DataAnnotations;

namespace EvoNaplo.Infrastructure.DataAccess.Entities
{
    public class StudentEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public StudentEntity() {}

        public StudentEntity(UserEntity student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Email = student.Email;
        }
    }
}
