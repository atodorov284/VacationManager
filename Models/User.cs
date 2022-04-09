using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    /// <summary>
    /// Initializes and encapsulated the logic of the user model.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identifying autoset User ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Username. Required field.
        /// </summary>
        [Required(ErrorMessage = "*This field is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MinLength(4)]
        [StringLength(15)]
        public string Username { get; set; }

        /// <summary>
        /// User's password. Required field.
        /// </summary>
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        /// <summary>
        /// User's firest name.
        /// </summary>
        [MinLength(3)]
        [Required(ErrorMessage = "*This field is Required!")]
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name.
        /// </summary>
        [MinLength(3)]
        [Required(ErrorMessage = "*This field is Required!")]
        public string LastName { get; set; }

        /// <summary>
        /// User's number, corresponding to their role, according the following enum:
        /// 0 - Unnasigned (Default)
        /// 1 - Developer 
        /// 2 - Leader
        /// 3 - CEO
        /// </summary>
        [Required(ErrorMessage = "*This field is Required!")]
        public int Role { get; set; }

        /// <summary>
        /// The team name, to which the user is assigned.
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// The project name, on which the user is currently working.
        /// </summary>
        public string Project { get; set; }
    }
}
