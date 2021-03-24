using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Withdraw.Domain;
using Withdraw.Messages;

namespace Withdraw.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WithdrawController : ControllerBase
    {
        private IWithdrawService _withdrawService { get; set; }
        public WithdrawController(IWithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }
        // POST api/<WithdrawController>
        [HttpPost("{accountnumber}")]
        public async Task<ActionResult<WithdrawResponse>> Post([FromRoute] string accountnumber, [FromBody] string amount)
        {
            var convertedAmount = Convert.ToDouble(amount);
            if (String.IsNullOrEmpty(accountnumber) || convertedAmount <= 0)
            {
                return BadRequest("Invalid accountnumber or amount");
            }

            try
            {
                var isSuccessfull = await _withdrawService.Withdraw(accountnumber, convertedAmount);


                return await Task.FromResult(new WithdrawResponse
                {
                    IsSuccessfull = isSuccessfull
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex);                
            }
            

        }
    }
}
