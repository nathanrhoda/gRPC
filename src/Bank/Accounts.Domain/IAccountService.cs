using Accounts.Domain.Models;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public interface IAccountService
    {
        Task<Account> GetAccountByGrpc(string accountNumber);
        Task<Account> UpdateBalanceByGrpc(string accountNumber, double amount);
    }
}
