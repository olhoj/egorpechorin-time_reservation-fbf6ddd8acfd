using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TR.Web.Models.Models;

namespace TR.Web.Services.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){}

        public DbSet<AcceptedSlot> AcceptedSlots { get; set; }
        public DbSet<Diapason> Diapasons { get; set; }
        public DbSet<MeetingVariant> MeetingVariants { get; set; }
        public DbSet<Slot> Slots { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slot>().ToTable("Slot");
            modelBuilder.Entity<AcceptedSlot>().ToTable("AcceptedSlot"); 
            modelBuilder.Entity<MeetingVariant>().ToTable("MeetingVariant");
            modelBuilder.Entity<Diapason>().ToTable("Diapason");
        }
        
    }
}
