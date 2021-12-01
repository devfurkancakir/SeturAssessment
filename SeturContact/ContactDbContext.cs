using Microsoft.EntityFrameworkCore;

namespace SeturContact.Models
{
    public class ContactDbContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}