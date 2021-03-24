using Accounts.Domain;
using Accounts.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Account.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {        
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET api/<AccountController>
        [HttpGet("{accountnumber}")]
        public async Task<ActionResult<AccountResponse>> Get([FromRoute] string accountnumber)
        {
            if (string.IsNullOrEmpty(accountnumber))
            {
                return BadRequest(accountnumber);
            }

            var account = await _accountService.GetAccountBy(accountnumber);

            if (account == null)
            {
                return NotFound(accountnumber);
            }

            return await Task.FromResult(new AccountResponse
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance
            });            

        }

        // POST api/<AccountController>
        [HttpPost("{accountnumber}")]
        public async Task<ActionResult<AccountResponse>> Post([FromRoute] string accountnumber, [FromBody] double amount)
        {
            if (string.IsNullOrEmpty(accountnumber))
            {
                return BadRequest(accountnumber);
            }

            var account = await _accountService.UpdateBalance(accountnumber, amount);

            if(account == null)
            {
                return NotFound(accountnumber);
            }

            return await Task.FromResult(new AccountResponse
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance
            });
        }
    }
}
