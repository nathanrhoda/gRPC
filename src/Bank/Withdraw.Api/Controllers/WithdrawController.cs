using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Withdraw.Messages;

namespace Withdraw.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WithdrawController : ControllerBase
    {

        // POST api/<WithdrawController>
        [HttpPost("{accountnumber}")]
        public async Task<ActionResult<WithdrawResponse>> Post([FromRoute] string accountnumber, [FromBody] double amount)
        {
            if (String.IsNullOrEmpty(accountnumber) || amount <= 0 )
            {
                return BadRequest("Invalid accountnumber or amount");
            }

            if (accountnumber == "123")
            {
                return await Task.FromResult(new WithdrawResponse
                {
                    IsSuccessfull = true
                });
            }

            return NotFound(accountnumber);
        }
    }
}
