using CalendarWebApp.Data;

namespace CalendarWebApp.Repository.IRepository
{
    public interface IOrganisationRepository
    {
        Task<List<Organisation>> GetAllAsync();
        Task<Organisation?> GetByIdAsync(int id);
        Task CreateAsync(Organisation organisation);
        Task UpdateAsync(Organisation organisation);
        Task<bool> DeleteAsync(int id);
    }
}
