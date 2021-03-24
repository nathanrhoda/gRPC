using Bank.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain
{
    public class WithdrawService : IWithdrawService
    {
        private readonly IHttpClientFactory _clientFactory;

        public WithdrawService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> Withdrawal(string accountNumber, double amount)
        {

            var account = await GetAccountDetails(accountNumber);

            if (!AccountExists(account))
            {
                throw new Exception("Account does not exist");
            }

            if (EnoughMoneyInAccountForWithdrawal(amount, account))
            {
                var withdrawDto = await ProcessWithdrawal(accountNumber, amount);

                if (WithdrawalWasSuccessfull(withdrawDto))
                {
                    var accountWithUpdatedBalance = await UpdateBalance(accountNumber, amount);

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

        #region Private Methods
        private static bool WithdrawalWasSuccessfull(WithdrawDto withdrawDto)
        {
            return withdrawDto != null && withdrawDto.IsSuccessfull;
        }

        private static bool EnoughMoneyInAccountForWithdrawal(double amount, AccountDto account)
        {
            return account.Balance > amount;
        }

        private static bool AccountExists(AccountDto account)
        {
            return account != null;
        }

        private async Task<AccountDto> GetAccountDetails(string accountNumber)
        {
            var client = _clientFactory.CreateClient("AccountApi");
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/account/{accountNumber}");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var contentJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AccountDto>(contentJson);
        }


        private async Task<WithdrawDto> ProcessWithdrawal(string accountNumber, double amount)
        {
            var client = _clientFactory.CreateClient("WithdrawApi");
            var content = new StringContent(amount.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/withdraw/{accountNumber}")
            {
                Content = content
            };
            
            
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var contentJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WithdrawDto>(contentJson);

        }

        private async Task<AccountDto> UpdateBalance(string accountNumber, double amount)
        {
            var client = _clientFactory.CreateClient("AccountApi");

            var content = new StringContent(amount.ToString(), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/account/{accountNumber}", content);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var contentJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AccountDto>(contentJson);
        } 
        #endregion
    }
}
