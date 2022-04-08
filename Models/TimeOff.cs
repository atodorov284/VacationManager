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

        public virtual bool HalfDay { get; set; } = false;

        [Required]
        public string Type { get; set; }

        public bool Approved { get; set; } = false;

        public DateTime CreatedOn { get; set; }
        public string RequestingUser { get; set; }
    }
}
