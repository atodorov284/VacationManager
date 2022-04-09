using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    /// <summary>
    /// Class Team.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        [MinLength(2, ErrorMessage = "Value cannot be less than 2")]
        [MaxLength(15, ErrorMessage = "Value cannot be more than 15")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the developers.
        /// </summary>
        /// <value>The developers.</value>
        public List<User> Developers { get; set; }

        /// <summary>
        /// Gets or sets the leader.
        /// </summary>
        /// <value>The leader.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        public string Leader { get; set; }
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public string Project { get; set; }
        /// <summary>
        /// Gets or sets the working projects.
        /// </summary>
        /// <value>The working projects.</value>
        public List<Project> WorkingProjects { get; set; }
    }
}
