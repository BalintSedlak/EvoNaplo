using EvoNaploTFS.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAppliable { get; set; }


        public Semester()
        {
        }
        public Semester(Semester semester)
        {
            Id = semester.Id;
            StartDate = semester.StartDate;
            EndDate = semester.EndDate;
            IsAppliable = semester.IsAppliable;
        }
    }
}
