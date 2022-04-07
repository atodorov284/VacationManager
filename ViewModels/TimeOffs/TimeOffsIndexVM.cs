using System.Collections.Generic;
using VacationManager.Models.TimeOffs;

namespace VacationManager.ViewModels.TimeOffs
{
    public class TimeOffsIndexVM
    {
        public List<PaidTimeOff> PaidTimeOffs { get; set; }

        public List<UnpaidTimeOff> UnpaidTimeOffs { get; set; }

        public List<SickTimeOff> SickTimeOffs { get; set; }
    }
}
