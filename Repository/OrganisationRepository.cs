using CalendarWebApp.Data;
using CalendarWebApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CalendarWebApp.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganisationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Organisation organisation)
        {
            _context.Organisations.Add(organisation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var organisation = await _context.Organisations
                .Include(o => o.Groups)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (organisation == null) return false;

            if (organisation.Groups.Any())
            {
                return false;
            }

            _context.Organisations.Remove(organisation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Organisation>> GetAllAsync()
        {
            return await _context.Organisations
                .Include(o => o.Groups)
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<Organisation?> GetByIdAsync(int id)
        {
            return await _context.Organisations.FindAsync(id);
        }

        public async Task UpdateAsync(Organisation organisation)
        {
            var existing = await _context.Organisations.FindAsync(organisation.Id);
            if (existing != null)
            {
                existing.Name = organisation.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
