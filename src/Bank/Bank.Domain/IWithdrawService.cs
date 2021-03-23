using System.Threading.Tasks;

namespace Bank.Domain
{
    public interface IWithdrawService
    {
        Task<string> Withdrawal(string accountNumber, double amount);
    }
}