using Accounts.Domain.Models;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public interface IAccountService
    {
        Task<Account> GetAccountBy(string accountNumber);
        Task<Account> UpdateBalance(string accountNumber, double amount);
    }
}
