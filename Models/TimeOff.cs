using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Models
{
    public class TimeOff
    {
        [Key]
        public int TimeOffId { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual bool HalfDay { get; set; } = false;

        public string Type { get; set; }

        [Required]
        public bool Approved { get; set; }

        [Required]
        public User RequestingUser { get; set; }
    }
}
