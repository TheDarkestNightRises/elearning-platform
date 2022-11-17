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
  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.Username,
      via.dk.elearn.protobuf.UserModel> getGetUserByNameMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUserByName",
      requestType = via.dk.elearn.protobuf.Username.class,
      responseType = via.dk.elearn.protobuf.UserModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.Username,
      via.dk.elearn.protobuf.UserModel> getGetUserByNameMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.Username, via.dk.elearn.protobuf.UserModel> getGetUserByNameMethod;
    if ((getGetUserByNameMethod = UserGrpc.getGetUserByNameMethod) == null) {
      synchronized (UserGrpc.class) {
        if ((getGetUserByNameMethod = UserGrpc.getGetUserByNameMethod) == null) {
          UserGrpc.getGetUserByNameMethod = getGetUserByNameMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.Username, via.dk.elearn.protobuf.UserModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUserByName"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.Username.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserModel.getDefaultInstance()))
              .setSchemaDescriptor(new UserMethodDescriptorSupplier("GetUserByName"))
              .build();
        }
      }
    }
    return getGetUserByNameMethod;
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

  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel,
      via.dk.elearn.protobuf.UserModel> getGetUserByIDMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUserByID",
      requestType = via.dk.elearn.protobuf.UserLookupModel.class,
      responseType = via.dk.elearn.protobuf.UserModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel,
      via.dk.elearn.protobuf.UserModel> getGetUserByIDMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.UserLookupModel, via.dk.elearn.protobuf.UserModel> getGetUserByIDMethod;
    if ((getGetUserByIDMethod = UserGrpc.getGetUserByIDMethod) == null) {
      synchronized (UserGrpc.class) {
        if ((getGetUserByIDMethod = UserGrpc.getGetUserByIDMethod) == null) {
          UserGrpc.getGetUserByIDMethod = getGetUserByIDMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.UserLookupModel, via.dk.elearn.protobuf.UserModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUserByID"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserLookupModel.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.UserModel.getDefaultInstance()))
              .setSchemaDescriptor(new UserMethodDescriptorSupplier("GetUserByID"))
              .build();
        }
      }
    }
    return getGetUserByIDMethod;
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
    public void getUserByName(via.dk.elearn.protobuf.Username request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserByNameMethod(), responseObserver);
    }

    /**
     */
    public void createNewUser(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getCreateNewUserMethod(), responseObserver);
    }

    /**
     */
    public void getUserByID(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserByIDMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetUserByNameMethod(),
            io.grpc.stub.ServerCalls.asyncServerStreamingCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.Username,
                via.dk.elearn.protobuf.UserModel>(
                  this, METHODID_GET_USER_BY_NAME)))
          .addMethod(
            getCreateNewUserMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.UserLookupModel,
                via.dk.elearn.protobuf.UserModel>(
                  this, METHODID_CREATE_NEW_USER)))
          .addMethod(
            getGetUserByIDMethod(),
            io.grpc.stub.ServerCalls.asyncServerStreamingCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.UserLookupModel,
                via.dk.elearn.protobuf.UserModel>(
                  this, METHODID_GET_USER_BY_ID)))
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
    public void getUserByName(via.dk.elearn.protobuf.Username request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncServerStreamingCall(
          getChannel().newCall(getGetUserByNameMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void createNewUser(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getCreateNewUserMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getUserByID(via.dk.elearn.protobuf.UserLookupModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncServerStreamingCall(
          getChannel().newCall(getGetUserByIDMethod(), getCallOptions()), request, responseObserver);
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
    public java.util.Iterator<via.dk.elearn.protobuf.UserModel> getUserByName(
        via.dk.elearn.protobuf.Username request) {
      return io.grpc.stub.ClientCalls.blockingServerStreamingCall(
          getChannel(), getGetUserByNameMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.dk.elearn.protobuf.UserModel createNewUser(via.dk.elearn.protobuf.UserLookupModel request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getCreateNewUserMethod(), getCallOptions(), request);
    }

    /**
     */
    public java.util.Iterator<via.dk.elearn.protobuf.UserModel> getUserByID(
        via.dk.elearn.protobuf.UserLookupModel request) {
      return io.grpc.stub.ClientCalls.blockingServerStreamingCall(
          getChannel(), getGetUserByIDMethod(), getCallOptions(), request);
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

  private static final int METHODID_GET_USER_BY_NAME = 0;
  private static final int METHODID_CREATE_NEW_USER = 1;
  private static final int METHODID_GET_USER_BY_ID = 2;

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
        case METHODID_GET_USER_BY_NAME:
          serviceImpl.getUserByName((via.dk.elearn.protobuf.Username) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel>) responseObserver);
          break;
        case METHODID_CREATE_NEW_USER:
          serviceImpl.createNewUser((via.dk.elearn.protobuf.UserLookupModel) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.UserModel>) responseObserver);
          break;
        case METHODID_GET_USER_BY_ID:
          serviceImpl.getUserByID((via.dk.elearn.protobuf.UserLookupModel) request,
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
              .addMethod(getGetUserByNameMethod())
              .addMethod(getCreateNewUserMethod())
              .addMethod(getGetUserByIDMethod())
              .build();
        }
      }
    }
    return result;
  }
}
