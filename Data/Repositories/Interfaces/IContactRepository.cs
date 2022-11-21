using Data.Entities.ContactEntity;

namespace Data.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> AddAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Contact FindByEmail(string email);
    }
}
