using Accounts.Server.Protos;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Accounts.Server.Protos.AccountGrpcService;

namespace Accounts.Server.Services
{
    public class AccountGrpcServiceImp : AccountGrpcServiceBase
    {
        public override async Task<AccountGrpcResponse> GetAccount(AccountGrpcRequest request, ServerCallContext context)
        {
            AccountGrpcResponse response = new AccountGrpcResponse();

            if (request.Accountnumber == "123")
            {
                response = new AccountGrpcResponse
                {
                    Accountnumber = request.Accountnumber,
                    Amount = Convert.ToInt64(20000)
                };
            }
            return await Task.FromResult(response);
        }

        public override async Task<AccountGrpcResponse> UpdateBalance(UpdateBalanceRequest request, ServerCallContext context)
        {

            AccountGrpcResponse response = new AccountGrpcResponse();

            if (request.Accountnumber == "123")
            {
                response = new AccountGrpcResponse
                {
                    Accountnumber = request.Accountnumber,
                    Amount = Convert.ToInt64(20000) - request.Amount
                };
            }
            return await Task.FromResult(response);
        }
    }
}
