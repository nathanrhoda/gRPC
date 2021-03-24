using System.Threading.Tasks;

namespace Withdraw.Domain
{
    public interface IWithdrawService
    {
        Task<bool> Withdraw(string accountnumber, double amount);
    }
}
