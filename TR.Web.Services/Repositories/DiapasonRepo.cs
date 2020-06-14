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
    public class DiapasonRepo : IDiapasonRepo
    {
        private readonly AppDbContext _context;

        public DiapasonRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddDiapason(Diapason newDiapason)
        {
            _context.Add(newDiapason);
            await _context.SaveChangesAsync();

            int slotDurationInMinutes = (_context.MeetingVariants.Find(newDiapason.MeetingVariantID).Duration.Hours * 60
                + _context.MeetingVariants.Find(newDiapason.MeetingVariantID).Duration.Minutes);

            int slotPerDay =
                ((newDiapason.FinishTime.Hour * 60 + newDiapason.FinishTime.Minute)
                - (newDiapason.StartTime.Hour * 60 + newDiapason.StartTime.Minute))
                / slotDurationInMinutes;


            for (DateTime date = newDiapason.StartDay; date <= newDiapason.FinishDay; date += TimeSpan.FromDays(1))
            {
                bool isOk = false;
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        isOk = newDiapason.IsMonday;
                        break;
                    case DayOfWeek.Tuesday:
                        isOk = newDiapason.IsTuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        isOk = newDiapason.IsWednesday;
                        break;
                    case DayOfWeek.Thursday:
                        isOk = newDiapason.IsThursday;
                        break;
                    case DayOfWeek.Friday:
                        isOk = newDiapason.IsFriday;
                        break;
                    case DayOfWeek.Saturday:
                        isOk = newDiapason.IsSaturday;
                        break;
                    case DayOfWeek.Sunday:
                        isOk = newDiapason.IsSaturday;
                        break;

                }

                if (isOk)
                {
                    for (int i = 0; i < slotPerDay; i++)
                    {
                        int slotStartsInMinutes = newDiapason.StartTime.Hour * 60 + newDiapason.StartTime.Minute + slotDurationInMinutes * (i);
                        int slotEndsInMinutes = slotStartsInMinutes + slotDurationInMinutes;
                        int stH = slotStartsInMinutes / 60;
                        int stM = slotStartsInMinutes - stH * 60;
                        int fiH = slotEndsInMinutes / 60;
                        int fiM = slotEndsInMinutes - fiH * 60;

                        _context.Add(new Slot
                        {
                            DiapasonID = newDiapason.DiapasonID,
                            MeetingVariantID = newDiapason.MeetingVariantID,
                            StartSlotTime = new DateTime(
                                date.Year,
                                date.Month,
                                date.Day,
                                stH,
                                stM,
                                00),
                            FinishSlotTime = new DateTime(
                                date.Year,
                                date.Month,
                                date.Day,
                                fiH,
                                fiM,
                                00),
                            IsAvailable = true
                        });

                        await _context.SaveChangesAsync();
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiapason(int diapasonId)
        {
            Diapason di = _context.Diapasons.Find(diapasonId);
            if (di != null)
            {
                _context.Diapasons.Remove(di);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Diapason> GetAllByMeetingId(int meetingId, string userId)
        {
            return _context.Diapasons.Where(x => x.MeetingVariantID == meetingId && x.User == userId);
        }
    }
}
