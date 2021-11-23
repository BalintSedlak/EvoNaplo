using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models.DTO
{
    public class SemesterDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IsAppliable {get;set;}

        public SemesterDTO()
        {
            Id = -1;
        }

        public SemesterDTO(Semester semester)
        {
            Id = semester.Id;
            StartDate = semester.StartDate;
            EndDate = semester.EndDate;
            IsAppliable = semester.IsAppliable ? "Active" : "Inactive";
        }
        public SemesterDTO(SemesterDTO semesterDTO)
        {
            Id = semesterDTO.Id;
            StartDate = semesterDTO.StartDate;
            EndDate = semesterDTO.EndDate;
            IsAppliable = semesterDTO.IsAppliable;
        }
    }
}
