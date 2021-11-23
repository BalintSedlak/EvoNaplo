using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoNaploTFS.Models.TableConnectors
{
    public class ProjectTechnologies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Technology { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
    }
}
