using System.Threading.Tasks;

namespace Withdraw.Domain
{
    public interface IWithdrawService
    {
        Task<bool> WithdrawGrpc(string accountnumber, double amount);        
    }
}
