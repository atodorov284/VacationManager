using System;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Models
{
    /// <summary>
    /// Class CustomDateRange.
    /// Implements the <see cref="RangeAttribute" />
    /// </summary>
    /// <seealso cref="RangeAttribute" />
    public class CustomDateRange : RangeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDateRange"/> class.
        /// </summary>
        public CustomDateRange() : base(typeof(DateTime), DateTime.Now.ToString(), DateTime.Now.AddYears(1).ToString())
        { }
    }
}
