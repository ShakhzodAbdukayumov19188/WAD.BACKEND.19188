using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19188.Models;

namespace WAD.BACKEND._19188.DATA
{
    public class ContactManagerDbContext:DbContext
    {
        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options) : base(options)
        { }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
