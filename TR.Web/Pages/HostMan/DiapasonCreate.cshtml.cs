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

namespace TR.Web.Pages.HostMan
{
    public class DiapasonCreateModel : PageModel
    {
        readonly IDiapasonRepo _diRepo;

        public Diapason Diapason { get; set; }
       public int CurrentID;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DiapasonCreateModel(IHttpContextAccessor httpContextAccessor, IDiapasonRepo diRep)
        {
            _diRepo = diRep;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnGet(int id)
        {
            CurrentID = id;
        }

        public async Task<IActionResult> OnPost(int id, Diapason newDia)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (newDia.StartDay != null && newDia.FinishDay != null && newDia.StartTime != null && newDia.FinishTime != null)
            {
                newDia.MeetingVariantID = id;
                newDia.User = userId;
                await _diRepo.AddDiapason(newDia);
                return Redirect("/HostMan/MeetingVariantManage/"+ id);
            }
            return Page();
        }

    }
}