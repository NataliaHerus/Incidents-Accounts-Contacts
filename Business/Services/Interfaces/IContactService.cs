using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactDto> CreateContactAsync(ContactDto dto);
    }
}
