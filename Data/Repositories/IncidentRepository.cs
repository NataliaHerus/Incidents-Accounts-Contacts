using Data.Data;
using Data.Entities.IncidentEntity;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        protected readonly IncidentsAccountsContactsDBContext _dbContext;
        public IncidentRepository(IncidentsAccountsContactsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Incident> AddAsync(Incident contact)
        {
            await _dbContext.Incidents!.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }
    }
}
