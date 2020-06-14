using System;
using System.Collections.Generic;
using System.Text;

namespace TR.Web.Models.Models
{
    public class Diapason
    {
        public int DiapasonID { get; set; }
        public string User { get; set; }
        public int MeetingVariantID { get; set; }
        public MeetingVariant MeetingVariant { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsSunday { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime FinishDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

    }
}
