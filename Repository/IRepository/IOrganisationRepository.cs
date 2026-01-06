using CalendarWebApp.Data;

namespace CalendarWebApp.Repository.IRepository
{
    public interface IOrganisationRepository
    {
        public Task<List<Organisation>> GetAllAsync();
        public Task<Organisation?> GetByIdAsync(int id);
        public Task CreateAsync(Organisation organisation);
        public Task UpdateAsync(Organisation organisation);
        public Task<bool> DeleteAsync(int id);
    }
}
