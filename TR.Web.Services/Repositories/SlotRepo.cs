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
    public class SlotRepo : ISlotRepo
    {
        private readonly AppDbContext _context;

        public SlotRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteSlotById(int slotId)
        {
            Slot sl = _context.Slots.Find(slotId);
            if (sl != null)
            {
                _context.Slots.Remove(sl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSlotsByDiapason(int diapasonId)
        {
            IEnumerable<Slot> slots = _context.Slots.Where(el => el.DiapasonID == diapasonId);
            if (slots != null)
            {
                foreach (Slot sl in slots)
                {
                    _context.Slots.Remove(sl);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSlotsByMeetingVariant(int mvId)
        {
            IEnumerable<Slot> slots = _context.Slots.Where(el => el.MeetingVariantID == mvId);
            if (slots != null)
            {
                foreach (Slot sl in slots)
                {
                    _context.Slots.Remove(sl);
                }
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Slot> GetSlotsByMeetingID(int mvId)
        {
            return _context.Slots.Where(el => el.MeetingVariantID == mvId);
        }

        public async  Task ChangeAvailabilityMark(int slotId, bool mark)
        {
            Slot sl = _context.Slots.Find(slotId);
            if (sl != null)
            {
                sl.IsAvailable = mark;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddSlot(Slot newSlot)
        {
            _context.Add(newSlot);
            await _context.SaveChangesAsync();
        }

        public Slot FindSlotById(int id)
        {
            return _context.Slots.Find(id);
        }
    }
}
