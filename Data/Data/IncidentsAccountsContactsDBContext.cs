using Data.Entities.AccountEntity;
using Data.Entities.ContactEntity;
using Data.Entities.IncidentEntity;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class IncidentsAccountsContactsDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
        }
        public IncidentsAccountsContactsDBContext(DbContextOptions<IncidentsAccountsContactsDBContext> options)
               : base(options)
        {

        }
    }
}
