using CalendarWebApp.Data;
using CalendarWebApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CalendarWebApp.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly ApplicationDbContext _db;
        public OrganisationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Organisation organisation)
        {
            _db.Organisations.Add(organisation);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var organisation = await _db.Organisations
                .Include(o => o.Groups)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (organisation == null) return false;

            if (organisation.Groups.Any())
            {
                return false;
            }

            _db.Organisations.Remove(organisation);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Organisation>> GetAllAsync()
        {
            return await _db.Organisations
                .Include(o => o.Groups)
                .ThenInclude(g => g.GroupLeader)
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<Organisation?> GetByIdAsync(int id)
        {
            return await _db.Organisations.FindAsync(id);
        }

        public async Task UpdateAsync(Organisation organisation)
        {
            var existing = await _db.Organisations.FindAsync(organisation.Id);
            if (existing != null)
            {
                existing.Name = organisation.Name;
                await _db.SaveChangesAsync();
            }
        }
    }
}
