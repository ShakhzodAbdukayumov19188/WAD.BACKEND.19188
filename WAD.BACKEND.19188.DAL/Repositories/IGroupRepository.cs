using WAD.BACKEND._19188.Models;

namespace WAD.BACKEND._19188.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task AddGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int id);
    }
}
