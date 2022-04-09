using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    /// <summary>
    /// Class User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MinLength(4, ErrorMessage = "Minimum length is 4.")]
        [MaxLength(15, ErrorMessage = "Maximum length is 15.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum length is 6.")]
        [MaxLength(15, ErrorMessage = "Maximum length is 15.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [MinLength(3, ErrorMessage = "Minimum length is 3.")]
        [Required(ErrorMessage = "*This field is Required!")]
        [MaxLength(15, ErrorMessage = "Maximum length is 15.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [MinLength(3, ErrorMessage = "Minimum length is 3.")]
        [Required(ErrorMessage = "*This field is Required!")]
        [MaxLength(15, ErrorMessage = "Maximum length is 15.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        [Required(ErrorMessage = "*This field is Required!")]
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>The team.</value>
        public string Team { get; set; }

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public string Project { get; set; }
    }
}
