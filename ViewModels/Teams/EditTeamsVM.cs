using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.ViewModels.Teams
{
    public class EditTeamsVM
    {
        public int Id { get; set; }

        [Display(Name = "TeamName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name of the team")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", ErrorMessage = "A name should only contain letters")]
        public string TeamName { get; set; }
        public IEnumerable<SelectListItem> TeamLeads { get; set; }
        public IEnumerable<string> Developers { get; set; }
        public string TeamLeadId { get; set; }
    }
}
