using System;
using System.Threading.Tasks;
using WithdrawIntegrationClient;

namespace Withdraw.Domain
{
    public class WithdrawService : IWithdrawService
    {
        public async Task<bool> WithdrawGrpc(string accountnumber, double amount)
        {            
            var client = new WithdrawClient();

            var response = await client.MakeWithdrawal(accountnumber, Convert.ToInt64(amount));
            var isSuccessfull = response.IsSuccessfull;

            return await Task.FromResult(isSuccessfull);
        }
    }
}
