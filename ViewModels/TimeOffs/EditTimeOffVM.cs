using System;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.ViewModels.TimeOffs
{
    public class EditTimeOffVM
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the start date of the vacation")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the end date of the vacation")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Half Day Vacation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter if it is half day vacation or not")]
        public bool IsHalfDayVacation { get; set; }

        [Display(Name = "Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the type of the vacation")]
        [MinLength(3, ErrorMessage = "Invalid type")]
        public string Type { get; set; }
    }
}
