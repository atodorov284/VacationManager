using System.Collections.Generic;
using VacationManager.Models;

namespace VacationManager.ViewModels.Teams
{
    public class TeamVM
    {
        public Team Team { get; set; }
        public IEnumerable<User> TeamDevelopers { get; set; }
    }
}
