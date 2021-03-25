using AccountIntegrationClient;
using Accounts.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class AccountService : IAccountService
    {
        private AccountClient _accountClient;

        public AccountService()
        {
            _accountClient = new AccountClient();
        }
        public async Task<Account> GetAccountByGrpc(string accountNumber)
        {
            var response = await _accountClient.FetchAccount(accountNumber);

            if (response == null)
            {
                return null;
            }

            var account = new Account
            {
                AccountNumber = response.Accountnumber,
                Balance = response.Amount
            };

            return await Task.FromResult(account);

        }


        public async Task<Account> UpdateBalanceByGrpc(string accountNumber, double amount)
        {
            var response = await _accountClient.UpdateBalance(accountNumber, amount);

            if (response == null)
            {
                return null;
            }

            var account = new Account
            {
                AccountNumber = response.Accountnumber,
                Balance = response.Amount
            };

            return await Task.FromResult(account);
        }
    }
}

