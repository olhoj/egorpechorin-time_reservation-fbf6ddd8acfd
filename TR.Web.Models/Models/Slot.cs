using System;
using System.Collections.Generic;
using System.Text;

namespace TR.Web.Models.Models
{
    public class Slot
    {
        public int SlotID { get; set; }
        public int DiapasonID { get; set; }
        public int MeetingVariantID { get; set; }
        public Diapason Diapason { get; set; }
        public MeetingVariant MeetingVariant { get; set; }
        public DateTime StartSlotTime { get; set; }
        public DateTime FinishSlotTime { get; set; }
        public DateTime Duration { get; set; }
        public bool IsAvailable { get; set; }


    }
}
