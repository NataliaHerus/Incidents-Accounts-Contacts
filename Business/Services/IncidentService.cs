using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities.AccountEntity;
using Data.Entities.ContactEntity;
using Data.Entities.IncidentEntity;
using Data.Repositories.Interfaces;


namespace Business.Services
{
    public class IncidentService : IIncidentService
    {
        protected readonly IIncidentRepository _incidentRepository;
        protected readonly IContactRepository _contactRepository;
        protected readonly IAccountRepository _accountRepository;
        protected readonly IMapper _mapper;

        public IncidentService(IIncidentRepository incidentRepository,
             IContactRepository contactRepository,
             IAccountRepository accountRepository,
             IMapper mapper)
        {
            _incidentRepository = incidentRepository;
            _contactRepository = contactRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IncidentDto> CreateIncidentAsync(IncidentDto dto)
        {
            var account = _accountRepository.FindByName(dto.Name!);
            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }

            var contact = _contactRepository.FindByEmail(dto.Email!);
            if (contact != null)
            {
                var newContact = _mapper.Map(dto, contact);
                if (contact.AccountId != account.Id)
                {
                    newContact.Account = account;
                }
                await _contactRepository.UpdateContactAsync(newContact);
            }
            else
            {
                var newContact = _mapper.Map<Contact>(dto);
                newContact.Account = account;
                await _contactRepository.AddAsync(newContact);
            }
            var newIncident = _mapper.Map<Incident>(dto);
            account.Incident = newIncident;

            await _accountRepository.UpdateAccountAsync(account);
            return dto;
        }
    }
}
