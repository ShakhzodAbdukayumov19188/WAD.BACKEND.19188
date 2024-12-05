using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19188.DATA;
using WAD.BACKEND._19188.Models;

namespace WAD.BACKEND._19188.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ContactManagerDbContext _context;

        public GroupRepository(ContactManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddGroupAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
