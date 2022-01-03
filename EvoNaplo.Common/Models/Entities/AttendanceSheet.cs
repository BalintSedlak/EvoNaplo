using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoNaplo.Common.Models.Entities
{
    public class AttendanceSheet
    {
        [Key]
        public int Id { get; set; }
        public DateTime MeetingDate { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
    }
}
