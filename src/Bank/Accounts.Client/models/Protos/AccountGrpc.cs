// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/account.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Accounts.Server.Protos {
  public static partial class AccountGrpcService
  {
    static readonly string __ServiceName = "account.AccountGrpcService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Accounts.Server.Protos.AccountGrpcRequest> __Marshaller_account_AccountGrpcRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Accounts.Server.Protos.AccountGrpcRequest.Parser));
    static readonly grpc::Marshaller<global::Accounts.Server.Protos.AccountGrpcResponse> __Marshaller_account_AccountGrpcResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Accounts.Server.Protos.AccountGrpcResponse.Parser));

    static readonly grpc::Method<global::Accounts.Server.Protos.AccountGrpcRequest, global::Accounts.Server.Protos.AccountGrpcResponse> __Method_GetAccount = new grpc::Method<global::Accounts.Server.Protos.AccountGrpcRequest, global::Accounts.Server.Protos.AccountGrpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAccount",
        __Marshaller_account_AccountGrpcRequest,
        __Marshaller_account_AccountGrpcResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Accounts.Server.Protos.AccountReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for AccountGrpcService</summary>
    public partial class AccountGrpcServiceClient : grpc::ClientBase<AccountGrpcServiceClient>
    {
      /// <summary>Creates a new client for AccountGrpcService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public AccountGrpcServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for AccountGrpcService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public AccountGrpcServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected AccountGrpcServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected AccountGrpcServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Accounts.Server.Protos.AccountGrpcResponse GetAccount(global::Accounts.Server.Protos.AccountGrpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAccount(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Accounts.Server.Protos.AccountGrpcResponse GetAccount(global::Accounts.Server.Protos.AccountGrpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAccount, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Accounts.Server.Protos.AccountGrpcResponse> GetAccountAsync(global::Accounts.Server.Protos.AccountGrpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAccountAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Accounts.Server.Protos.AccountGrpcResponse> GetAccountAsync(global::Accounts.Server.Protos.AccountGrpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAccount, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override AccountGrpcServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new AccountGrpcServiceClient(configuration);
      }
    }

  }
}
#endregion