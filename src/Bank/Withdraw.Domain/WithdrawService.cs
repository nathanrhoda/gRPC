using System;
using System.Threading.Tasks;

namespace Withdraw.Domain
{
    public class WithdrawService : IWithdrawService
    {
        public async Task<bool> Withdraw(string accountnumber, double amount)
        {
            var isSuccessfull = false;
            if (accountnumber == "123")
            {
                isSuccessfull = true;
            }

            return await Task.FromResult(isSuccessfull);
        }
    }
}
