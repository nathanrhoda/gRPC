using Grpc.Net.Client;
using HelloGrpc;
using System;
using System.Threading.Tasks;
using static HelloGrpc.Greeter;

namespace HelloRpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GreeterClient(channel);

            var request = new HelloRequest
            {
                Name = "Nathan"
            };

            var response = await client.SayHelloAsync(request);
            Console.WriteLine(response.Message);
            Console.ReadKey();
        }
    }
}
