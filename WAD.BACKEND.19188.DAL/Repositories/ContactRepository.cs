using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19188.DATA;
using WAD.BACKEND._19188.Models;
using WAD.BACKEND._19188.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactManagerDbContext _context;

    public ContactRepository(ContactManagerDbContext context)
    {
        _context = context;
    }

    // This method should fetch the Group by ID (used in POST)
    public async Task<Group> GetGroupByIdAsync(int groupId)
    {
        return await _context.Groups.FindAsync(groupId);
    }

    public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
    {
        return await _context.Contacts
                             .Include(c => c.Group)  
                             .ToListAsync();
    }

    public async Task<Contacts> GetContactByIdAsync(int id)
    {
        return await _context.Contacts
                             .Include(c => c.Group)  
                             .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddContactAsync(Contacts contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContactAsync(Contacts contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContactAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
