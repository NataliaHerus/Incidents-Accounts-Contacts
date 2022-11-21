using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities.AccountEntity;
using Data.Repositories.Interfaces;

namespace Business.Services
{
    public class AccountService : IAccountService
    {
        protected readonly IAccountRepository _accountRepository;
        protected readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<AccountDto> CreateAccountAsync(AccountDto dto)
        {
            var account = _mapper.Map<Account>(dto);
            var newAccount = await _accountRepository.AddAsync(account);

            return _mapper.Map<AccountDto>(newAccount);
        }
    }
}
