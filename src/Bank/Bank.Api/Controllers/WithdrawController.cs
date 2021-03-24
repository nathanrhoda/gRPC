using Bank.Domain;
using Bank.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        public IWithdrawService _withdrawService { get; set; }
        public WithdrawController(IWithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }
        // POST api/<WithdrawController>
        [HttpPost]
        public async Task<ActionResult<WithdrwaResponse>> Post([FromBody] WithdrawRequest request)
        {
            if (!request.IsValid())
            {
                return BadRequest(request);
            }

            try
            {
                var result = await _withdrawService.Withdrawal(request.AccountNumber, request.Amount);

                return await Task.FromResult(new WithdrwaResponse
                {
                    Result = result,
                    TransactionId = Guid.NewGuid().ToString()
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}