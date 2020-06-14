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
    public class MeetingVariantRepo : IMeetingVariantRepo
    {
        private readonly AppDbContext _context;

        public MeetingVariantRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task ChangeMV(int mvId, MeetingVariant newMV)
        {
            MeetingVariant mv = _context.MeetingVariants.Find(mvId);
            if (mv != null)
            {
                mv.Title = newMV.Title;
                mv.Description = newMV.Description;
                mv.Duration = newMV.Duration;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MeetingVariant> CreateMV(MeetingVariant newMV)
        {
            //newMV.MeetingVariantID = _context.MeetingVariants.Count()+1;
            _context.Add(newMV);
            await _context.SaveChangesAsync();
            return newMV;
        }

        public async Task DeleteMV(int mvId)
        {
            MeetingVariant mv = _context.MeetingVariants.Find(mvId);
            if(mv != null)
            {
                _context.MeetingVariants.Remove(mv);
                await _context.SaveChangesAsync();
            }
        }

        public MeetingVariant GetMeetingVariantById(int mvId, string userId)
        {
            var el = _context.MeetingVariants.Find(mvId);
            if (el != null)
            {
                /////baaaaad shit
                return el;
                if (el.Owner == userId)
                {
                    return el;
                }
                else
                {
                    return null;
                }
            }
            return el;
        }

        public IEnumerable<MeetingVariant> GetMeetingVariants(string owner)
        {
            return _context.MeetingVariants.Where(el => el.Owner == owner);
        }
    }
}
