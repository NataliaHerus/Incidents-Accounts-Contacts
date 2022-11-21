using Data.Data;
using Data.Entities.AccountEntity;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly IncidentsAccountsContactsDBContext _dbContext;
        public AccountRepository(IncidentsAccountsContactsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Account> AddAsync(Account account)
        {
            await _dbContext.Accounts!.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return account;
        }

        public Account FindByName(string name)
        {
            var account = _dbContext.Accounts!.FirstOrDefault(x => x.Name == name);
            return account;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            await Task.Run(() => _dbContext.Entry(account).State = EntityState.Modified);
            await _dbContext.SaveChangesAsync();
            return account;
        }
    }
}
