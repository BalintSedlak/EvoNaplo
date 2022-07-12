using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Infrastructure.Models.TableConnectors
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AttendanceSheetId")]
        public int AttendanceSheetId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
    }
}
