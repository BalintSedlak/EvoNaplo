using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.Infrastructure.Models.DTO
{
    public class AttendanceDTO
    {
        public string Name { get; set; }
        public string Semester { get; set; }
        public string Project { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
