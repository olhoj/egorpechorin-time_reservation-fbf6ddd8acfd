using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TR.Web.Models.Models;
using TR.Web.Services.Interfaces;

namespace TR.Web
{
    public class MeetingVariantManageModel : PageModel
    {
        readonly IMeetingVariantRepo _mvRepo;
        readonly IDiapasonRepo _diRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MeetingVariantManageModel(IHttpContextAccessor httpContextAccessor, IMeetingVariantRepo mvRep, IDiapasonRepo diRep)
        {
            _mvRepo = mvRep;
            _diRepo = diRep;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public int CurrentID { get; set; }

        [BindProperty]
        public MeetingVariant MeetingVariant {get;set;}
        public IEnumerable<Diapason> Diapasons { get; set; }
        public bool isCreated { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            CurrentID = id;
            isCreated = false;
            MeetingVariant = _mvRepo.GetMeetingVariantById(id,null);
            if(MeetingVariant != null) isCreated = true;
            if (MeetingVariant != null && userId != MeetingVariant.Owner) return Redirect("/HostMan/AccountPage");
            Diapasons = _diRepo.GetAllByMeetingId(id, userId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(MeetingVariant newMV)
        {
            if (MeetingVariant.Title != null && MeetingVariant.Duration != null && MeetingVariant.Description != null)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                MeetingVariant.Owner = userId;
                if (CurrentID == null || CurrentID == 0)
                {
                    MeetingVariant = await _mvRepo.CreateMV(MeetingVariant);
                }
                else
                {
                    await _mvRepo.ChangeMV(CurrentID, MeetingVariant);
                }
                return Redirect("/HostMan/MeetingVariantManage/" + MeetingVariant.MeetingVariantID);
            }
            else
            {
                return Page();
            }

        }

        public async Task<IActionResult> OnPostBackSave(int id, MeetingVariant newMV)
        {
            if (MeetingVariant.Title != null && MeetingVariant.Duration != null && MeetingVariant.Description != null)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                MeetingVariant.Owner = userId;
                if (id == null || id == 0)
                {
                    MeetingVariant = await _mvRepo.CreateMV(MeetingVariant);
                }
                else
                {
                    await _mvRepo.ChangeMV(id, MeetingVariant);
                }
                return Redirect("/HostMan/AccountPage");
            }
            else{
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDelete(int idD, int idM)
        {
            await _diRepo.DeleteDiapason(idD);
            return Redirect("/HostMan/MeetingVariantManage/"+idM);
        }


    }
}