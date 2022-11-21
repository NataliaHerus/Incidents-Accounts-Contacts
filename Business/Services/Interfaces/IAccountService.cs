using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccountAsync(AccountDto dto);
    }
}
