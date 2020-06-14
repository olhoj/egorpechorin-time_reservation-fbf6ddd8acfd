using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TR.Web.Models.Models;
using TR.Web.Services.Interfaces;

namespace TR.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepo _rep;

        public IndexModel(ILogger<IndexModel> logger, IRepo rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IEnumerable<TestObject> Objects { get; set; }

        public void OnGet()
        {
            Objects = _rep.GetTestData();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            return Redirect("/Stranger/MeetingReservation/" + id);
        }
    }
}
