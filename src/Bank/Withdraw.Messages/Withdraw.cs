using System;

namespace Withdraw.Messages
{
    public class WithdrawRequest
    {
        public string AccountNumber { get; set; }

        public double Amount { get; set; }

        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(AccountNumber) && Amount > 0)
            {
                return true;
            }

            return false;
        }
    }

    public class WithdrawResponse
    {
        public bool IsSuccessfull { get; set; }
    }
}
