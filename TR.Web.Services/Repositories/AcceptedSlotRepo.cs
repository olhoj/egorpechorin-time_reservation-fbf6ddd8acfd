using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Web.Models.Models;
using TR.Web.Services.Data;
using TR.Web.Services.Interfaces;

namespace TR.Web.Services.Repositories
{
    public class AcceptedSlotRepo : IAcceptedSlotRepo
    {
        private readonly AppDbContext _context;

        public AcceptedSlotRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddSlot(AcceptedSlot newAcceptedSlot)
        {
            _context.Add(newAcceptedSlot);
            Slot slot = _context.Slots.Find(newAcceptedSlot.SlotID);
            slot.IsAvailable = false;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSlot(int slotId)
        {
            AcceptedSlot ac = _context.AcceptedSlots.Find(slotId);
            if (ac != null)
            {
                _context.Slots.Find(ac.SlotID).IsAvailable = true;
                _context.AcceptedSlots.Remove(ac);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<AcceptedSlot> GetAllAcceptedSlots(string user)
        {
            IEnumerable<AcceptedSlot> results = _context.AcceptedSlots.Where(el => el.Owner == user);
            foreach (AcceptedSlot sl in results)
            {
                sl.Slot = _context.Slots.Find(sl.SlotID);
                //sl.Slot.Diapason = _context.Diapasons.Find(sl.Slot.DiapasonID);
                //sl.Slot.Diapason.MeetingVariant = _context.MeetingVariants.Find(sl.Slot.Diapason.MeetingVariantID);
                sl.Slot.MeetingVariant = _context.MeetingVariants.Find(sl.Slot.MeetingVariantID);
            }
            return results;
        }
    }
}
