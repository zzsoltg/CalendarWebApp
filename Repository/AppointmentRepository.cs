using Microsoft.EntityFrameworkCore;
using CalendarWebApp.Repository.IRepository;
using RadzenBlazorDemos;
using CalendarWebApp.Data;

namespace CalendarWebApp.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;

        public AppointmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> CalculateFreeDays(string userId, int year)
        {
            DateTime yearStart = new DateTime(year, 1, 1);
            DateTime yearEnd = new DateTime(year, 12, 31);

            var appointments = await _db.Appointment
                .Where(a => a.UserId == userId
                && a.Type == "Szabadság"
                && a.Start.Date <= yearEnd
                && a.End.Date >= yearStart)
                .ToListAsync();
            return appointments.Sum(x => (x.End.Date - x.Start.Date).Days + 1);


        }

        public async Task<Appointment> CreateAsync(Appointment obj)
        {
            await _db.Appointment.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Appointment.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Appointment.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync(string? userId = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new List<Appointment>();
            }
            return await _db.Appointment.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Appointment> GetAsync(int id)
        {
            var obj = await _db.Appointment.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Appointment();
            }
            return obj;
        }

        public async Task<IEnumerable<Appointment>> GetByUsersAsync(List<string> userIds)
        {
            return await _db.Appointment
                    .Where(a => userIds.Contains(a.UserId))
                    .ToListAsync();
        }

        public async Task<Appointment> UpdateAsync(Appointment obj)
        {
            var objFromDb = await _db.Appointment.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Start = obj.Start;
                objFromDb.End = obj.End;
                objFromDb.Type = obj.Type;
                objFromDb.Description = obj.Description;
                objFromDb.UserId = obj.UserId;
                objFromDb.Id = obj.Id;
                _db.Appointment.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }

        public async Task<int> GetWeeklyHomeOfficeCount(string userId, DateTime targetDate)
        {
            int diff = (7 + (targetDate.DayOfWeek - DayOfWeek.Monday)) % 7;
            var monday = targetDate.AddDays(-1 * diff).Date;
            var sunday = monday.AddDays(6).Date;

            return await _db.Appointment.CountAsync(x =>
                x.UserId == userId &&
                x.Type == "HomeOffice" &&
                x.Start.Date >= monday &&
                x.Start.Date <= sunday);
        }
    }
}
