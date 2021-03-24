using Accounts.Domain;
using Accounts.Server.Protos;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Accounts.Server.Protos.AccountGrpcService;

namespace Accounts.Server.Services
{
    public class AccountGrpcServiceImp : AccountGrpcServiceBase
    {
        private IAccountService _accountService { get; set; }
        public AccountGrpcServiceImp(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task<AccountGrpcResponse> GetAccount(AccountGrpcRequest request, ServerCallContext context)
        {
            var account = await _accountService.GetAccountBy(request.Accountnumber);
            return await Task.FromResult(
                new AccountGrpcResponse
                {
                    Accountnumber = account.AccountNumber,
                    Amount = Convert.ToInt64(account.Balance)
                });
        }
    }
}
