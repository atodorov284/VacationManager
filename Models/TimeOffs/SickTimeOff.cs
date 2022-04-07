using System.ComponentModel.DataAnnotations.Schema;

namespace VacationManager.Models.TimeOffs
{
    public class SickTimeOff : TimeOff
    {
        public string PathAttachment { get; set; }
        [NotMapped]
        public override bool HalfDay { get; set; }
    }
}
