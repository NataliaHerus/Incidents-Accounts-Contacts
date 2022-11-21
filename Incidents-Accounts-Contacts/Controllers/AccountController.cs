using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidents_Accounts_Contacts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountDto account)
        {
            try
            {
                return Ok(await _accountService.CreateAccountAsync(account));
            }
            catch
            {
                return BadRequest("Contact email and account name must be unique values");
            }
        }
    }
}
