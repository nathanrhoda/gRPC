using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountIntegrationClient
{
    public interface IAccountClient
    {
        Task<AccountGrpcResponse> FetchAccount(string accountNumber);
        Task<AccountGrpcResponse> UpdateBalance(string accountNumber, double amount);
    }
}
