using CalendarWebApp.Data;

namespace CalendarWebApp.Repository.IRepository
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllHierarchicalAsync();
        Task<List<Group>> GetHierarchicalGroupsByOrganisationAsync(int organisationId);
        Task<List<Group>> GetAllLogicalAsync();
        Task<Group?> GetByIdAsync(int id);
        Task CreateAsync(Group group);
        Task UpdateAsync(Group group);
        Task<bool> DeleteAsync(int id);

        Task AddUserToLogicalGroupAsync(string userId, int groupId);
        Task RemoveUserFromLogicalGroupAsync(string userId, int groupId);
    }
}
