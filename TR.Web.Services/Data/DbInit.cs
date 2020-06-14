using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TR.Web.Models.Models;

namespace TR.Web.Services.Data
{
    public class DbInit
    {
        public static void Initialize(AppDbContext context)
        {
            
            if (context.AcceptedSlots.Any())
            {
                return;
            }

            List<MeetingVariant> mvs = new List<MeetingVariant>()
            {
                new MeetingVariant
                {
                    Title = "Discussion - Economics in 2020",
                    Description = "Lets discuss about economics and its changes in 2020!",
                    Duration = new TimeSpan(0,1,0,0), // 1 hour
                    Owner = "user1"
                },
                new MeetingVariant
                {
                    Title = "Debate schools today",
                    Description = "Which problems you can find in scools, how whey can be solved, what do you think about current situation",
                    Duration = new TimeSpan(0,2,0,0), // 1 hour
                    Owner = "user1"
                },
                new MeetingVariant
                {
                    Title = "Question about profession",
                    Description = "What is the most boring action in your current work?",
                    Duration = new TimeSpan(0,0,15,0), // 1 hour
                    Owner = "user1"
                },
                new MeetingVariant
                {
                    Title = "Question about free time",
                    Description = "What are you prefer doing at free time? Lets talk about hobbies and free time spending",
                    Duration = new TimeSpan(0,0,20,0), // 1 hour
                    Owner = "user1",
                },
                new MeetingVariant
                {
                    Title = "Consultation in marketing",
                    Description = "Problem solving, strategy planning and other stuff making",
                    Duration = new TimeSpan(0,3,0,0), // 1 hour
                    Owner = "user1",
                },
                new MeetingVariant
                {
                    Title = "Pre-consultation in marketing",
                    Description = "Personal marketing BOOOM plan creating and all works planning",
                    Duration = new TimeSpan(0,0,30,0), // 1 hour
                    Owner = "user1",
                },
            };

            foreach (MeetingVariant mv in mvs)
            {
                context.MeetingVariants.Add(mv);
            }

            context.SaveChanges();

            List<Diapason> dia = new List<Diapason>()
            {
                new Diapason
                {
                    MeetingVariantID = mvs[0].MeetingVariantID,
                    IsMonday = true,
                    IsTuesday = true,
                    IsWednesday = true,
                    IsThursday = true,
                    IsFriday = true,
                    IsSaturday = false,
                    IsSunday = false,
                    StartDay = new DateTime(2020,04,20,01,01,01),
                    FinishDay = new DateTime(2020,06,20,01,01,01),
                    StartTime = new DateTime(1000,01,01,12,00,00),
                    FinishTime = new DateTime(1000,01,01,16,00,00),
                },
                new Diapason
                {
                    MeetingVariantID = mvs[0].MeetingVariantID,
                    IsMonday = true,
                    IsTuesday = true,
                    IsWednesday = true,
                    IsThursday = true,
                    IsFriday = true,
                    IsSaturday = false,
                    IsSunday = false,
                    StartDay = new DateTime(2020,04,20,01,01,01),
                    FinishDay = new DateTime(2020,06,20,01,01,01),
                    StartTime = new DateTime(1000,01,01,17,00,00),
                    FinishTime = new DateTime(1000,01,01,19,00,00),
                },
                new Diapason
                {
                    MeetingVariantID = mvs[0].MeetingVariantID,
                    IsMonday = true,
                    IsTuesday = true,
                    IsWednesday = true,
                    IsThursday = false,
                    IsFriday = false,
                    IsSaturday = false,
                    IsSunday = false,
                    StartDay = new DateTime(2020,04,20,01,01,01),
                    FinishDay = new DateTime(2020,06,20,01,01,01),
                    StartTime = new DateTime(1000,01,01,08,00,00),
                    FinishTime = new DateTime(1000,01,01,10,00,00),
                },
            };

            foreach (Diapason mv in dia)
            {
                context.Diapasons.Add(mv);
            }

            context.SaveChanges();

            List<Slot> slo = new List<Slot>();

            foreach(Diapason d in dia)
            {
                for (DateTime date = d.StartDay; date.Date <= d.FinishDay.Date; date = date.AddDays(1))
                {
                    for(int i = 0; i < (d.FinishTime.Hour- d.StartTime.Hour); i++)
                    {
                        slo.Add(
                            new Slot
                            {
                                DiapasonID = d.DiapasonID,
                                MeetingVariantID = mvs[0].MeetingVariantID,
                                StartSlotTime = new DateTime(
                                    year: date.Year,
                                    month: date.Month,
                                    day: date.Day,
                                    hour: d.StartTime.Hour + i,
                                    minute: 00,
                                    second:00 
                                    ),
                                FinishSlotTime = new DateTime(
                                    year: date.Year,
                                    month: date.Month,
                                    day: date.Day,
                                    hour: d.StartTime.Hour + i + 1,
                                    minute: 00,
                                    second:00
                                    ),
                                IsAvailable = true
                            }
                        );
                    }
                }
            }

            foreach (Slot sl in slo)
            {
                context.Slots.Add(sl);
            }

            context.SaveChanges();


            context.AcceptedSlots.Add(
                new AcceptedSlot
                {
                    SlotID = slo[2].SlotID,
                    Owner = "user1",
                    ClientName = "Vasily",
                }
            );
            context.Add(new AcceptedSlot
            {
                SlotID = slo[3].SlotID,
                Owner = "user1",
                ClientName = "Anna",
            });
            context.Add(
                new AcceptedSlot
                {
                    SlotID = slo[10].SlotID,
                    Owner = "user1",
                    ClientName = "Tamara",
                });

            context.SaveChanges();
        }
    }
}

