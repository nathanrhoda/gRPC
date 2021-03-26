using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Withdraw.Server.Services
{
    public class WithdrawServiceImpl : WithdrawGrpcService.WithdrawGrpcServiceBase
    {
        public override async Task<WithdrawRespone> MakeWithdrawal(WithdrawRequest request, ServerCallContext context)
        {
            var response = new WithdrawRespone
            {
                IsSuccessfull = false
            };
            
            if (request.Accountnumber == "123")
            {
                response.IsSuccessfull = true;
            }

            return await Task.FromResult(response);            
        }
    }
}
