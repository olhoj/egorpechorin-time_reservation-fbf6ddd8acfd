using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TR.Web.Models.Models;

namespace TR.Web.Services.Interfaces
{
    public interface IAcceptedSlotRepo
    {
        IEnumerable<AcceptedSlot> GetAllAcceptedSlots(string user);
        Task DeleteSlot(int slotId);
        Task AddSlot(AcceptedSlot newAcceptedSlot);
    }
}
