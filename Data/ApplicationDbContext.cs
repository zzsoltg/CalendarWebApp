using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor.Rendering;
using RadzenBlazorDemos;
using MyAppointment = RadzenBlazorDemos.Appointment;

namespace CalendarWebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<MyAppointment> Appointment { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MyAppointment>().HasData(
                new MyAppointment { Id = 1, Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Type="Szabadság" },
                new MyAppointment { Id = 2, Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Type="HomeOffice" },
                new MyAppointment { Id = 3, Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Type="Képzés" }
            );

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.HierarchicalGroup)
                .WithMany(g => g.HierarchicalMembers)
                .HasForeignKey(u => u.HierarchicalGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.LogicalGroups)
                .WithMany(g => g.LogicalMembers)
                .UsingEntity(j => j.ToTable("UserLogicalGroups"));

            builder.Entity<Group>()
            .HasOne(g => g.GroupLeader)
            .WithMany()
            .HasForeignKey(g => g.GroupLeaderId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ApplicationUser>()
                        .Property(u => u.DateOfBirth)
                        .HasColumnType("date");

        }
    }
}
