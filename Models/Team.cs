using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VacationManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [Required]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        public List<User> Developers { get; set; }

        [Required]
        public string Leader { get; set; }
        public string Project { get; set; }
        public List<Project> WorkingProjects { get; set; }
    }
}
