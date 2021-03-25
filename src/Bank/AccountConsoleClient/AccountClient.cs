using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace AccountIntegrationClient
{
    public class AccountClient : IAccountClient
    {
        public async Task<AccountGrpcResponse> FetchAccount(string accountNumber)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:24311");
            var client = new AccountGrpcService.AccountGrpcServiceClient(channel);

            var request = new AccountGrpcRequest
            {
                Accountnumber = accountNumber
            };

            var response = await client.GetAccountAsync(request);

            //Needed cos gRpc services dont do nulls
            if (response.Accountnumber == "")
            {
                response = null;
            }

            return response;
        }

        public async Task<AccountGrpcResponse> UpdateBalance(string accountNumber, double amount)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:24311");
            var client = new AccountGrpcService.AccountGrpcServiceClient(channel);

            var request = new UpdateBalanceRequest
            {
                Accountnumber = accountNumber,
                Amount = Convert.ToInt64(amount)
            };

            var response = await client.UpdateBalanceAsync(request);

            //Needed cos gRpc services dont do nulls
            if (response.Accountnumber == "")
            {
                response = null;
            }

            return response;
        }
    }
}
