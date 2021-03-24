using Accounts.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class AccountService : IAccountService
    {
        private double _defaultBalance = 10000;
        public async Task<Account> GetAccountBy(string accountNumber)
        {
            Account account = null;
            if (accountNumber == "123")
            {
                account = new Account
                {
                    AccountNumber = accountNumber,
                    Balance = _defaultBalance
                };
            }

            return await Task.FromResult(account);

        }

        public async Task<Account> UpdateBalance(string accountNumber, double amount)
        {
            Account account = null;
            if (accountNumber == "123")
            {
                account = new Account
                {
                    AccountNumber = accountNumber,
                    Balance = _defaultBalance
                };
            }

            return await Task.FromResult(account);
        }
    }
}

