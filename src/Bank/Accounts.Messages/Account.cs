using System;

namespace Accounts.Messages
{
    public class AccountRequest
    {
        public string AccountNumber { get; set; }

        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(AccountNumber))
            {
                return true;
            }

            return false;
        }
    }

    public class AccountResponse
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

    }
}
