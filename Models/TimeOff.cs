using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Models
{
    /// <summary>
    /// Initializes and encapsulated the logic of the vacation model.
    /// </summary>
    public class TimeOff
    { 
        /// <summary>
        /// Identifying autoset Vacation ID.
        /// </summary>
        [Key]
        public int TimeOffId { get; set; }

        /// <summary>
        /// The date, on which the timeoff starts. Required field.
        /// </summary>
        [Required]
        public DateTime From { get; set; }

        /// <summary>
        /// The date, on which the timeoff ends. Required field.
        /// </summary>
        [Required]
        public DateTime To { get; set; }

        /// <summary>
        /// Conditional on if the timeoff is half the day.
        /// </summary>
        public virtual bool HalfDay { get; set; } = false;

        /// <summary>
        /// Additional information on the vacation. Required field.
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Conditional on if the vacation is approved by the manager.
        /// </summary>
        public bool Approved { get; set; } = false;

        /// <summary>
        /// The date on which the request for timeoff has been created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The name of the user, who is requesting the timeoff.
        /// </summary>
        public string RequestingUser { get; set; }
    }
}
