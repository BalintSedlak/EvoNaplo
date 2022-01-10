using EvoNaplo.Infrastructure.DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace EvoNaplo.Infrastructure.Models.Entities
{
    public class SemesterEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAppliable { get; set; }


        public SemesterEntity()
        {
        }

        public SemesterEntity(SemesterEntity semester)
        {
            Id = semester.Id;
            StartDate = semester.StartDate;
            EndDate = semester.EndDate;
            IsAppliable = semester.IsAppliable;
        }
    }
}
