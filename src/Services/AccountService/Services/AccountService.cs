using AccountService.Protos;
using Grpc.Core;
using System.Threading.Tasks;
using static AccountService.Protos.Account;

namespace AccountService.Services
{
    public class AccountService : AccountBase
    {
        public override Task<AccountReply> CheckBalance(AccountRequest request, ServerCallContext context)
        {
            return base.CheckBalance(request, context);
        }
    }
}
