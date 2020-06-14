using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TR.Web.Models.Models;
using TR.Web.Services.Interfaces;

namespace TR.Web
{
    public class AccountPageModel : PageModel
    {
        readonly IMeetingVariantRepo _mvRepo;
        readonly IAcceptedSlotRepo _acRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountPageModel(IHttpContextAccessor httpContextAccessor, IMeetingVariantRepo mvRep, IAcceptedSlotRepo acRep)
        {
            _mvRepo = mvRep;
            _acRepo = acRep;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<MeetingVariant> MeetingVariants { get; set; }
        public IEnumerable<AcceptedSlot> AcceptedSlots { get; set; }

        public void OnGet()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            MeetingVariants =  _mvRepo.GetMeetingVariants(userId);
            AcceptedSlots = _acRepo.GetAllAcceptedSlots(userId);
            /*
            foreach (AcceptedSlot acS in AcceptedSlots)
            {
                acS.Slot = _slRepo.FindSlotById(acS.SlotID);
            }
            */
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _mvRepo.DeleteMV(id);
            return Redirect("/HostMan/AccountPage");
        }
        public async Task<IActionResult> OnPostDetails(int id)
        {
            return Redirect("/HostMan/MeetingVariantManage/"+ id);
        }

        public async Task<IActionResult> OnPostDeleteacceptedslot(int id)
        {
            await _acRepo.DeleteSlot(id);
            return Redirect("/HostMan/AccountPage");
        }
    }
}