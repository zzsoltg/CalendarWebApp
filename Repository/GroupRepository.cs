using CalendarWebApp.Data;
using CalendarWebApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CalendarWebApp.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _db;
        public GroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddUserToLogicalGroupAsync(string userId, int groupId)
        {
            var user = await _db.Users
                .Include(u => u.LogicalGroups)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var group = await _db.Groups.FindAsync(groupId);

            if (user != null && group != null)
            {
                if (!user.LogicalGroups.Any(g => g.Id == groupId))
                {
                    user.LogicalGroups.Add(group);
                    await _db.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetMembersByGroupNamesAsync(IEnumerable<string> groupNames, bool isLogical)
        {
            var query = _db.Users
                .Include(u => u.HierarchicalGroup)
                .ThenInclude(g => g.Organisation)
                .Include(u => u.LogicalGroups)
                .AsQueryable();

            if (groupNames != null && groupNames.Any())
            {
                if (isLogical)
                {
                    query = query.Where(u => u.LogicalGroups.Any(lg => groupNames.Contains(lg.Name)));
                }
                else
                {
                    query = query.Where(u => groupNames.Contains(u.HierarchicalGroup.Name));
                }
            }

            return await query.ToListAsync();
        }

        public async Task<List<Group>> GetHierarchicalGroupsByOrganisationAsync(int organisationId)
        {
            return await _db.Groups
                .Where(g => g.OrganisationId == organisationId)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task CreateAsync(Group group)
        {
            _db.Groups.Add(group);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var group = await _db.Groups
                .Include(g => g.HierarchicalMembers)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null) return false;

            if (group.HierarchicalMembers.Any())
            {
                return false;
            }

            _db.Groups.Remove(group);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Group>> GetAllHierarchicalAsync()
        {
            return await _db.Groups
                .Where(g => g.OrganisationId != null)
                .Include(g => g.Organisation)
                .Include(g => g.GroupLeader)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<List<Group>> GetAllLogicalAsync()
        {
            return await _db.Groups
                .Where(g => g.OrganisationId == null)
                .Include(g => g.GroupLeader)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            return await _db.Groups
                .Include(g => g.Organisation)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task RemoveUserFromLogicalGroupAsync(string userId, int groupId)
        {
            var user = await _db.Users
                .Include(u => u.LogicalGroups)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                var groupToRemove = user.LogicalGroups.FirstOrDefault(g => g.Id == groupId);
                if (groupToRemove != null)
                {
                    user.LogicalGroups.Remove(groupToRemove);
                    await _db.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateAsync(Group group)
        {
            var existing = await _db.Groups.FindAsync(group.Id);
            if (existing != null)
            {
                existing.Name = group.Name;
                await _db.SaveChangesAsync();
            }
        }
    }
}
