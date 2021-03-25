using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WithdrawIntegrationClient
{
    public interface IWithdrawClient
    {
        Task<WithdrawRespone> MakeWithdrawal(string accountnumber, double amount);
    }
}
