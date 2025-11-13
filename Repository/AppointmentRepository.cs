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

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _db.Appointment.ToListAsync();
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

        public async Task<Appointment> UpdateAsync(Appointment obj)
        {
            var objFromDb = await _db.Appointment.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Start = obj.Start;
                objFromDb.End = obj.End;
                objFromDb.Text = obj.Text;
                _db.Appointment.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
