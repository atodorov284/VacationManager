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

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public List<User> Developers { get; set; }

        [Required]
        public User Leader { get; set; }

        public int? LeaderId { get; set; }

        public List<Project> WorkingProjects { get; set; }
    }
}
