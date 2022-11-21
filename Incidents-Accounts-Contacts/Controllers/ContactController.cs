using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidents_Accounts_Contacts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        protected readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactDto contact)
        {
            try
            {
                return Ok(await _contactService.CreateContactAsync(contact));
            }
            catch
            {
                return BadRequest("Contact with such email already exists");
            }
        }
    }
}
