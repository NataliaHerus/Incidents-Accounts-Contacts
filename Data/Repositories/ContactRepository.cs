using Data.Data;
using Data.Entities.ContactEntity;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly IncidentsAccountsContactsDBContext _dbContext;
        public ContactRepository(IncidentsAccountsContactsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Contact> AddAsync(Contact contact)
        {
            await _dbContext.Contacts!.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public Contact FindByEmail(string email)
        {
            var contact = _dbContext.Contacts!.FirstOrDefault(x => x.Email == email);
            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            await Task.Run(() => _dbContext.Entry(contact).State = EntityState.Modified);
            await _dbContext.SaveChangesAsync();
            return contact;
        }
    }
}
