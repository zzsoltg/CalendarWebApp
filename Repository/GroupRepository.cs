using CalendarWebApp.Data;
using CalendarWebApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CalendarWebApp.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserToLogicalGroupAsync(string userId, int groupId)
        {
            var user = await _context.Users
                .Include(u => u.LogicalGroups)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var group = await _context.Groups.FindAsync(groupId);

            if (user != null && group != null)
            {
                if (!user.LogicalGroups.Any(g => g.Id == groupId))
                {
                    user.LogicalGroups.Add(group);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Group>> GetHierarchicalGroupsByOrganisationAsync(int organisationId)
        {
            return await _context.Groups
                .Where(g => g.OrganisationId == organisationId)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task CreateAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var group = await _context.Groups
                .Include(g => g.HierarchicalMembers)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null) return false;

            if (group.HierarchicalMembers.Any())
            {
                return false;
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Group>> GetAllHierarchicalAsync()
        {
            return await _context.Groups
                .Where(g => g.OrganisationId != null)
                .Include(g => g.Organisation)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<List<Group>> GetAllLogicalAsync()
        {
            return await _context.Groups
                .Where(g => g.OrganisationId == null)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            return await _context.Groups
                .Include(g => g.Organisation)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task RemoveUserFromLogicalGroupAsync(string userId, int groupId)
        {
            var user = await _context.Users
                .Include(u => u.LogicalGroups)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                var groupToRemove = user.LogicalGroups.FirstOrDefault(g => g.Id == groupId);
                if (groupToRemove != null)
                {
                    user.LogicalGroups.Remove(groupToRemove);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateAsync(Group group)
        {
            var existing = await _context.Groups.FindAsync(group.Id);
            if (existing != null)
            {
                existing.Name = group.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
