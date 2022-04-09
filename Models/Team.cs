using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VacationManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    /// <summary>
    /// Initializes and encapsulated the logic of the team model.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Identifying autoset Team ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        /// <summary>
        /// Team name. Required field.
        /// </summary>
        [Required]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        /// <summary>
        /// List of the users, having their Role set to 1 (Developer), who are working on this team.
        /// </summary>
        public List<User> Developers { get; set; }

        /// <summary>
        /// Name of the user, who is assigned to this team as Leader and has a Role set to 2 (Leader).
        /// Required field.
        /// </summary>
        [Required]
        public string Leader { get; set; }

        /// <summary>
        /// Name of the Project, the team is currently working on.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Name of the projects, the team is assigned to.
        /// </summary>
        public List<Project> WorkingProjects { get; set; }
    }
}
