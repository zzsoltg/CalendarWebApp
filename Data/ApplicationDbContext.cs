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
                new MyAppointment { Id = 1, Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Birthday" },
                new MyAppointment { Id = 2, Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "Day off" },
                new MyAppointment { Id = 3, Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "Work from home" },
                new MyAppointment { Id = 4, Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(12), Text = "Online meeting" },
                new MyAppointment { Id = 5, Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(13), Text = "Skype call" },
                new MyAppointment { Id = 6, Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(14).AddMinutes(30), Text = "Dentist appointment" },
                new MyAppointment { Id = 7, Start = DateTime.Today.AddDays(1), End = DateTime.Today.AddDays(12), Text = "Vacation" }
            );
        }
    }
}
