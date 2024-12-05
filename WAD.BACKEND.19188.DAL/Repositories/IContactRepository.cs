using WAD.BACKEND._19188.Models;

namespace WAD.BACKEND._19188.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task AddContactAsync(Contacts contact);
        Task UpdateContactAsync(Contacts contact);
        Task DeleteContactAsync(int id);
        Task<Group> GetGroupByIdAsync(int groupId);
    }
}
