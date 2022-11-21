using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentDto> CreateIncidentAsync(IncidentDto dto);
    }
}
