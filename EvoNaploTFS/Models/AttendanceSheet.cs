using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models
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
