using System.ComponentModel.DataAnnotations;

namespace EvoNaplo.Infrastructure.DataAccess.Entities
{
    public class StudentEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string PhoneNumber {get; set; }

        [Required]
        public string Technologies { get; set; }

        [Required]
        public bool Scholarship { get; set; }

        [Required]
        public bool FbGroup { get; set; }

        [Required]
        public bool Internship { get; set; }

        public StudentEntity() {}
    }
}
