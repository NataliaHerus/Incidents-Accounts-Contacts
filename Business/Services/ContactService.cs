using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities.ContactEntity;
using Data.Repositories.Interfaces;

namespace Business.Services
{
    public class ContactService : IContactService
    {
        protected readonly IContactRepository _contactRepository;
        protected readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<ContactDto> CreateContactAsync(ContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            var newContact = await _contactRepository.AddAsync(contact);

            return _mapper.Map<ContactDto>(newContact);
        }
    }
}
