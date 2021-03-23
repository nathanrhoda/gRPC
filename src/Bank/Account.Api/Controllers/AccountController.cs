using Accounts.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Account.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private double _defaultBalance = 10000;
        // GET api/<AccountController>
        [HttpGet("{accountnumber}")]
        public async Task<ActionResult<AccountResponse>> Get([FromRoute]string accountnumber)
        {            
            if (string.IsNullOrEmpty(accountnumber))
            {
                return BadRequest(accountnumber);
            }
                     
            if (accountnumber == "123")
            {
                return await Task.FromResult(new AccountResponse
                {
                    AccountNumber = "123",
                    Balance = _defaultBalance
                });
            }

            return NotFound(accountnumber);

         
        }

        // POST api/<AccountController>
        [HttpPost("{accountnumber}")]
        public async Task<ActionResult<AccountResponse>> Post([FromRoute]string accountnumber, [FromBody] double amount)
        {
            if (string.IsNullOrEmpty(accountnumber))
            {
                return BadRequest(accountnumber);
            }

            return await Task.FromResult(new AccountResponse
            {
                AccountNumber = accountnumber,
                Balance = _defaultBalance - amount
            });
        }
    }
}
