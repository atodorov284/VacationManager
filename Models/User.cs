using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*This field is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MinLength(4)]
        [StringLength(15)]
        public string Username { get; set; }

        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "*This field is Required!")]
        public string FirstName { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "*This field is Required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*This field is Required!")]
        public int Role { get; set; }

        public string Team { get; set; }

        public string Project { get; set; }
    }
}
