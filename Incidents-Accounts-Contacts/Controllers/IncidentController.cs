using Business.Models;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidents_Accounts_Contacts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        protected readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncidentDto icident)
        {
            try
            {
                var incident = await _incidentService.CreateIncidentAsync(icident);
                return Ok(incident);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
