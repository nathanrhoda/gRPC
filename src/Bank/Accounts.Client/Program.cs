using Accounts.Server.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Accounts.Client
{
    public class Program
    {
        const string target = "127.0.0.1:24311";
        async static Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:24311");
            //await channel.ConnectAsync().ContinueWith(async (task) =>
            //{
                //if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                //{
                    Console.WriteLine("The client connected successfully");
                //}

                var client = new AccountGrpcService.AccountGrpcServiceClient(channel);
                var request = new AccountGrpcRequest
                {
                    Accountnumber = "123"
                };

                var account = await client.GetAccountAsync(request);
                Console.WriteLine($"Account Number: {account.Accountnumber}");
                Console.WriteLine($"Balance: {account.Amount}");


                channel.ShutdownAsync().Wait();


            //});

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
