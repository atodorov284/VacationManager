using System;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Models
{
    /// <summary>
    /// Class DateGreaterThanAttribute.
    /// Implements the <see cref="ValidationAttribute" />
    /// </summary>
    /// <seealso cref="ValidationAttribute" />
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        /// <summary>
        /// The comparison property
        /// </summary>
        private readonly string _comparisonProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateGreaterThanAttribute"/> class.
        /// </summary>
        /// <param name="comparisonProperty">The comparison property.</param>
        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.</returns>
        /// <exception cref="System.ArgumentException">Property with this name not found</exception>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue < comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
