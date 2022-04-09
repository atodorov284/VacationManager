using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    /// <summary>
    /// Initializes and encapsulated the logic of the project model.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Identifying autoset Project ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        /// <summary>
        /// Project name. Required field.
        /// </summary>
        [Required]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        /// <summary>
        /// Description of the Project. Required field.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        /// <summary>
        /// Team requested to be assigned on the project.
        /// </summary>
        public string TeamToAdd { get; set; }

        /// <summary>
        /// Team requested to be removed from the project.
        /// </summary>
        public string TeamToRemove { get; set; }

        /// <summary>
        /// Names of the teams, which are working on the project.
        /// </summary>
        public string TeamNames { get; set; }

        /// <summary>
        /// List of the teams. which are working on the project.
        /// </summary>
        public List<Team> Teams { get; set; }
    }
}
