using System.Threading.Tasks;

namespace Bank.Domain
{
    public interface IWithdrawService
    {        
        Task<string> WithdrawalGprc(string accountNumber, double amount);
    }
}