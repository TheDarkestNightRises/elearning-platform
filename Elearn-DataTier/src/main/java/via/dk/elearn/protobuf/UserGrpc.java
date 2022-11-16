package via.dk.elearn.protobuf;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.39.0)",
    comments = "Source: user.proto")
public final class UserGrpc {

  private UserGrpc() {}

  public static final String SERVICE_NAME = "User";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel,
      via.dk.elearn.protobuf.UserModel> getGetUserByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUserById",
      requestType = via.dk.elearn.protobuf.UserLookupModel.class,
      responseType = via.dk.elearn.protobuf.UserModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel,
      via.dk.elearn.protobuf.UserModel> getGetUserByIdMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel, via.dk.elearn.protobuf.UserModel> getGetUserByIdMethod;
    if ((getGetUserByIdMethod = UserGrpc.getGetUserByIdMethod) == null) {
      synchronized (UserGrpc.class) {
        if ((getGetUserByIdMethod = UserGrpc.getGetUserByIdMethod) == null) {
          UserGrpc.getGetUserByIdMethod = getGetUserByIdMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.UserLookupModel, via.dk.elearn.protobuf.UserModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUserById"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserLookupModel.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserModel.getDefaultInstance()))
              .setSchemaDescriptor(new UserMethodDescriptorSupplier("GetUserById"))
              .build();
        }
      }
    }
    return getGetUserByIdMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel,
      via.dk.elearn.protobuf.UserModel> getCreateNewUserMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "CreateNewUser",
      requestType = via.dk.elearn.protobuf.UserLookupModel.class,
      responseType = via.dk.elearn.protobuf.UserModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel,
      via.dk.elearn.protobuf.UserModel> getCreateNewUserMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel, via.dk.elearn.protobuf.UserModel> getCreateNewUserMethod;
    if ((getCreateNewUserMethod = UserGrpc.getCreateNewUserMethod) == null) {
      synchronized (UserGrpc.class) {
        if ((getCreateNewUserMethod = UserGrpc.getCreateNewUserMethod) == null) {
          UserGrpc.getCreateNewUserMethod = getCreateNewUserMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.UserLookupModel, via.dk.elearn.protobuf.UserModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "CreateNewUser"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserLookupModel.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserModel.getDefaultInstance()))
              .setSchemaDescriptor(new UserMethodDescriptorSupplier("CreateNewUser"))
              .build();
        }
      }
    }
    return getCreateNewUserMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static UserStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UserStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UserStub>() {
        @java.lang.Override
        public UserStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UserStub(channel, callOptions);
        }
      };
    return UserStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static UserBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UserBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UserBlockingStub>() {
        @java.lang.Override
        public UserBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UserBlockingStub(channel, callOptions);
        }
      };
    return UserBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static UserFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UserFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UserFutureStub>() {
        @java.lang.Override
        public UserFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UserFutureStub(channel, callOptions);
        }
      };
    return UserFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class UserImplBase implements io.grpc.BindableService {

    /**
     */
    public void getUserById(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserByIdMethod(), responseObserver);
    }

    /**
     */
    public void createNewUser(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getCreateNewUserMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetUserByIdMethod(),
            io.grpc.stub.ServerCalls.asyncServerStreamingCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.UserLookupModel,
                via.dk.elearn.protobuf.UserModel>(
                  this, METHODID_GET_USER_BY_ID)))
          .addMethod(
            getCreateNewUserMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.UserLookupModel,
                via.dk.elearn.protobuf.UserModel>(
                  this, METHODID_CREATE_NEW_USER)))
          .build();
    }
  }

  /**
   */
  public static final class UserStub extends io.grpc.stub.AbstractAsyncStub<UserStub> {
    private UserStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UserStub(channel, callOptions);
    }

    /**
     */
    public void getUserById(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncServerStreamingCall(
          getChannel().newCall(getGetUserByIdMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void createNewUser(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getCreateNewUserMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class UserBlockingStub extends io.grpc.stub.AbstractBlockingStub<UserBlockingStub> {
    private UserBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UserBlockingStub(channel, callOptions);
    }

    /**
     */
    public java.util.Iterator<via.dk.elearn.protobuf.UserModel> getUserById(
        via.dk.elearn.protobuf.UserLookupModel request) {
      return io.grpc.stub.ClientCalls.blockingServerStreamingCall(
          getChannel(), getGetUserByIdMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.dk.elearn.protobuf.UserModel createNewUser(via.dk.elearn.protobuf.UserLookupModel request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getCreateNewUserMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class UserFutureStub extends io.grpc.stub.AbstractFutureStub<UserFutureStub> {
    private UserFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UserFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.dk.elearn.protobuf.UserModel> createNewUser(
        via.dk.elearn.protobuf.UserLookupModel request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getCreateNewUserMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_USER_BY_ID = 0;
  private static final int METHODID_CREATE_NEW_USER = 1;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final UserImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(UserImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_USER_BY_ID:
          serviceImpl.getUserById((via.dk.elearn.protobuf.UserLookupModel) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel>) responseObserver);
          break;
        case METHODID_CREATE_NEW_USER:
          serviceImpl.createNewUser((via.dk.elearn.protobuf.UserLookupModel) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class UserBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    UserBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return via.dk.elearn.protobuf.UserOuterClass.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("User");
    }
  }

  private static final class UserFileDescriptorSupplier
      extends UserBaseDescriptorSupplier {
    UserFileDescriptorSupplier() {}
  }

  private static final class UserMethodDescriptorSupplier
      extends UserBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    UserMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (UserGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new UserFileDescriptorSupplier())
              .addMethod(getGetUserByIdMethod())
              .addMethod(getCreateNewUserMethod())
              .build();
        }
      }
    }
    return result;
  }
}
