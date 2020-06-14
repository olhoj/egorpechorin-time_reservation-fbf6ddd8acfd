
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TR.Web.Models.Models
{
    public class AcceptedSlot
    {
        public int AcceptedSlotID { get; set; }
        public int SlotID { get; set; }
        public virtual Slot Slot { get; set; }
        public string Owner { get; set; }
        [Required(ErrorMessage = "Please write your name!")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Please give your contacts!")]
        public string ClientContactMail { get; set; }
        public string ClientComment { get; set; }

    }
}
