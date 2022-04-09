using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    /// <summary>
    /// Class Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        [MinLength(2, ErrorMessage = "Minimum length is 2.")]
        [MaxLength(15, ErrorMessage = "Maximum length is 15.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        [MinLength(2, ErrorMessage = "Minimum length is 2.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100.")]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the team to add.
        /// </summary>
        /// <value>The team to add.</value>
        public string TeamToAdd { get; set; }
        /// <summary>
        /// Gets or sets the team to remove.
        /// </summary>
        /// <value>The team to remove.</value>
        public string TeamToRemove { get; set; }
        /// <summary>
        /// Gets or sets the team names.
        /// </summary>
        /// <value>The team names.</value>
        public string TeamNames { get; set; }
        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        /// <value>The teams.</value>
        public List<Team> Teams { get; set; }
    }
}
