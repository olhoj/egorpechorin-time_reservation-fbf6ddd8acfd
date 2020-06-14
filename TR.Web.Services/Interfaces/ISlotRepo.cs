using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TR.Web.Models.Models;

namespace TR.Web.Services.Interfaces
{
    public interface ISlotRepo
    {
        IEnumerable<Slot> GetSlotsByMeetingID(int mvId);
        Task ChangeAvailabilityMark(int slotId, bool mark);
        Task DeleteSlotById(int slotId);
        Task DeleteSlotsByMeetingVariant(int mvId);
        Task DeleteSlotsByDiapason(int diapasonId);
        Task AddSlot(Slot newSlot);
        Slot FindSlotById(int id);
    }
}
