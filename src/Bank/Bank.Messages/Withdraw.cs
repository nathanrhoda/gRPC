using System;
using System.Collections.Generic;

namespace Bank.Messages
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

    public class WithdrwaResponse
    {
        public string TransactionId { get; set; }
        public string Result { get; set; }        
    }
}
