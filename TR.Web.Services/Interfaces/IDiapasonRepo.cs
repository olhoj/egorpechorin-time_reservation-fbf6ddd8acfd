using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TR.Web.Models.Models;

namespace TR.Web.Services.Interfaces
{
    public interface IDiapasonRepo
    {
        IEnumerable<Diapason> GetAllByMeetingId(int meetingId, string userId);
        Task AddDiapason(Diapason newDiapason);
        Task DeleteDiapason(int diapasonId);

    }
}
