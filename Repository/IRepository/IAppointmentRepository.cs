using RadzenBlazorDemos;

namespace CalendarWebApp.Repository.IRepository
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> CreateAsync(Appointment obj);
        public Task<Appointment> UpdateAsync(Appointment obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Appointment> GetAsync(int id);
        public Task<IEnumerable<Appointment>> GetAllAsync(string? userId = null);
    }
}
