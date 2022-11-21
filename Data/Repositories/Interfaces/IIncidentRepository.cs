using Data.Entities.IncidentEntity;

namespace Data.Repositories.Interfaces
{
    public interface IIncidentRepository
    {
        Task<Incident> AddAsync(Incident contact);
    }
}
