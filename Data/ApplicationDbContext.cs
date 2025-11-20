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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MyAppointment>().HasData(
                new MyAppointment { Id = 1, Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Szabi", Type="Szabadság" },
                new MyAppointment { Id = 2, Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "HO", Type="HomeOffice" },
                new MyAppointment { Id = 3, Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "AI tanfolyam", Type="Képzés" }
            );
        }
    }
}
