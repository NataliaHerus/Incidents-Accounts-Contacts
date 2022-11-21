using Data.Entities.AccountEntity;

namespace Data.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> AddAsync(Account account);

        Account FindByName(string name);
        Task<Account> UpdateAccountAsync(Account account);
    }
}
