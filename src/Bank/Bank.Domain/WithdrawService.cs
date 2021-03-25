using AccountIntegrationClient;
using Bank.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WithdrawIntegrationClient;

namespace Bank.Domain
{
    public class WithdrawService : IWithdrawService
    {        
        private IAccountClient _accountClient;
        private IWithdrawClient _withdrawClient;

        public WithdrawService(IAccountClient accountClient, IWithdrawClient withdrawClient)
        {
            _accountClient = accountClient;
            _withdrawClient = withdrawClient;
        }

        public async Task<string> WithdrawalGprc(string accountNumber, double amount)
        {
            var accountResponse = await _accountClient.FetchAccount(accountNumber);
            if (accountResponse == null)
            {
                throw new Exception("Account does not exist");
            }

            if (accountResponse.Amount > amount)
            {
                var withdrawalResponse = await _withdrawClient.MakeWithdrawal(accountNumber, amount);

                if (withdrawalResponse != null && withdrawalResponse.IsSuccessfull)
                {
                    var accountWithUpdatedBalance = await _accountClient.UpdateBalance(accountNumber, amount);
                    if (accountWithUpdatedBalance != null)
                    {
                        return "Successfull withdrawal";
                    }
                }
                else
                {
                    return "Unsuccessfull withdrawal";
                }
            }

            return "Not Enough cash in account to do withdrawal";
        }
    }
}
