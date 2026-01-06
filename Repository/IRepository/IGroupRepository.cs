using CalendarWebApp.Data;

namespace CalendarWebApp.Repository.IRepository
{
    public interface IGroupRepository
    {
        public Task<List<Group>> GetAllHierarchicalAsync();
        public Task<List<Group>> GetHierarchicalGroupsByOrganisationAsync(int organisationId);
        public Task<List<Group>> GetAllLogicalAsync();
        public Task<Group?> GetByIdAsync(int id);
        public Task CreateAsync(Group group);
        public Task UpdateAsync(Group group);
        public Task<bool> DeleteAsync(int id);
        public Task<IEnumerable<ApplicationUser>> GetMembersByGroupNamesAsync(IEnumerable<string> groupNames, bool isLogical);
        public Task AddUserToLogicalGroupAsync(string userId, int groupId);
        public Task RemoveUserFromLogicalGroupAsync(string userId, int groupId);
    }
}
