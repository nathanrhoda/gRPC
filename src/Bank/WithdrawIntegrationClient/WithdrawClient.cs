using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace WithdrawIntegrationClient
{
    public class WithdrawClient : IWithdrawClient
    {
        public async Task<WithdrawRespone> MakeWithdrawal(string accountnumber, double amount)
        {
            WithdrawRequest request = new WithdrawRequest
            {
                Accountnumber = accountnumber,
                Amount = Convert.ToInt64(amount)
            };
            using var channel = GrpcChannel.ForAddress("http://localhost:24313");
            var client = new WithdrawGrpcService.WithdrawGrpcServiceClient(channel);
            
            var response = await client.MakeWithdrawalAsync(request);

            return response;
        }
    }
}
