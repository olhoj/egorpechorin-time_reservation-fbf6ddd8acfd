using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TR.Web.Models.Models;
using TR.Web.Services.Interfaces;

namespace TR.Web
{
    public class MeetingReservationModel : PageModel
    {
        readonly ISlotRepo _slotRepo;
        readonly IAcceptedSlotRepo _acRepo;
        readonly IMeetingVariantRepo _mvRepo;
        public MeetingReservationModel(ISlotRepo sRep, IAcceptedSlotRepo acRep, IMeetingVariantRepo mcRepo)
        {
            _slotRepo = sRep;
            _acRepo = acRep;
            _mvRepo = mcRepo;
        }

        public IEnumerable<Slot> Slots { get;  set; }
        [BindProperty]
        public AcceptedSlot AcceptedSlot { get; set; }
        public MeetingVariant MeetingVariant { get;  set; }
        public Slot SelectedSlot { get; set; }
        public Slot FinalSlot { get; set; }

        public async Task<IActionResult> OnGet(int id, int? day, int? course)
        {
            ////CHANGE ASAP!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Slots = _slotRepo.GetSlotsByMeetingID(id);
            MeetingVariant = _mvRepo.GetMeetingVariantById(id, null);
            if(Slots == null || MeetingVariant == null) return Redirect("/Index");
            if(day != null) SelectedSlot = Slots.FirstOrDefault(el => el.SlotID == day);
            if (course != null) FinalSlot = Slots.FirstOrDefault(el => el.SlotID == day);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id,int mvId, string mvOW, AcceptedSlot newSlot)
        {
            if (AcceptedSlot.ClientName != null && AcceptedSlot.ClientContactMail != null )
            {


                //NOT DONE!! firstly correct display slots and reduct form!!
                AcceptedSlot.SlotID = id;
                AcceptedSlot.Owner = mvOW;
                await _acRepo.AddSlot(AcceptedSlot);
                return Redirect("/Index");

            }
            else
            {
                return Redirect("/Stranger/MeetingReservation/"+ mvId + "?day="+ id + "&course="+ id );
            }
        }
    }
}