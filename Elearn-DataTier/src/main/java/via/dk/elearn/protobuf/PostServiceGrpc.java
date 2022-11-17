package via.dk.elearn.protobuf;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.39.0)",
    comments = "Source: post.proto")
public final class PostServiceGrpc {

  private PostServiceGrpc() {}

  public static final String SERVICE_NAME = "PostService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostUrl,
      via.dk.elearn.protobuf.PostModel> getGetPostMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetPost",
      requestType = via.dk.elearn.protobuf.PostUrl.class,
      responseType = via.dk.elearn.protobuf.PostModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostUrl,
      via.dk.elearn.protobuf.PostModel> getGetPostMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostUrl, via.dk.elearn.protobuf.PostModel> getGetPostMethod;
    if ((getGetPostMethod = PostServiceGrpc.getGetPostMethod) == null) {
      synchronized (PostServiceGrpc.class) {
        if ((getGetPostMethod = PostServiceGrpc.getGetPostMethod) == null) {
          PostServiceGrpc.getGetPostMethod = getGetPostMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.PostUrl, via.dk.elearn.protobuf.PostModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetPost"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostUrl.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostModel.getDefaultInstance()))
              .setSchemaDescriptor(new PostServiceMethodDescriptorSupplier("GetPost"))
              .build();
        }
      }
    }
    return getGetPostMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.NewPostRequest,
      via.dk.elearn.protobuf.PostModel> getGetAllPostMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetAllPost",
      requestType = via.dk.elearn.protobuf.NewPostRequest.class,
      responseType = via.dk.elearn.protobuf.PostModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.NewPostRequest,
      via.dk.elearn.protobuf.PostModel> getGetAllPostMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.NewPostRequest, via.dk.elearn.protobuf.PostModel> getGetAllPostMethod;
    if ((getGetAllPostMethod = PostServiceGrpc.getGetAllPostMethod) == null) {
      synchronized (PostServiceGrpc.class) {
        if ((getGetAllPostMethod = PostServiceGrpc.getGetAllPostMethod) == null) {
          PostServiceGrpc.getGetAllPostMethod = getGetAllPostMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.NewPostRequest, via.dk.elearn.protobuf.PostModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetAllPost"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.NewPostRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostModel.getDefaultInstance()))
              .setSchemaDescriptor(new PostServiceMethodDescriptorSupplier("GetAllPost"))
              .build();
        }
      }
    }
    return getGetAllPostMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostModel,
      via.dk.elearn.protobuf.PostModel> getCreateNewPostMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "CreateNewPost",
      requestType = via.dk.elearn.protobuf.PostModel.class,
      responseType = via.dk.elearn.protobuf.PostModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostModel,
      via.dk.elearn.protobuf.PostModel> getCreateNewPostMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostModel, via.dk.elearn.protobuf.PostModel> getCreateNewPostMethod;
    if ((getCreateNewPostMethod = PostServiceGrpc.getCreateNewPostMethod) == null) {
      synchronized (PostServiceGrpc.class) {
        if ((getCreateNewPostMethod = PostServiceGrpc.getCreateNewPostMethod) == null) {
          PostServiceGrpc.getCreateNewPostMethod = getCreateNewPostMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.PostModel, via.dk.elearn.protobuf.PostModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "CreateNewPost"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostModel.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostModel.getDefaultInstance()))
              .setSchemaDescriptor(new PostServiceMethodDescriptorSupplier("CreateNewPost"))
              .build();
        }
      }
    }
    return getCreateNewPostMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostId,
      via.dk.elearn.protobuf.PostModel> getGetByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetById",
      requestType = via.dk.elearn.protobuf.PostId.class,
      responseType = via.dk.elearn.protobuf.PostModel.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostId,
      via.dk.elearn.protobuf.PostModel> getGetByIdMethod() {
    io.grpc.MethodDescriptor<via.dk.elearn.protobuf.PostId, via.dk.elearn.protobuf.PostModel> getGetByIdMethod;
    if ((getGetByIdMethod = PostServiceGrpc.getGetByIdMethod) == null) {
      synchronized (PostServiceGrpc.class) {
        if ((getGetByIdMethod = PostServiceGrpc.getGetByIdMethod) == null) {
          PostServiceGrpc.getGetByIdMethod = getGetByIdMethod =
              io.grpc.MethodDescriptor.<via.dk.elearn.protobuf.PostId, via.dk.elearn.protobuf.PostModel>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetById"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostId.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.dk.elearn.protobuf.PostModel.getDefaultInstance()))
              .setSchemaDescriptor(new PostServiceMethodDescriptorSupplier("GetById"))
              .build();
        }
      }
    }
    return getGetByIdMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static PostServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PostServiceStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<PostServiceStub>() {
        @java.lang.Override
        public PostServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new PostServiceStub(channel, callOptions);
        }
      };
    return PostServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static PostServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PostServiceBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<PostServiceBlockingStub>() {
        @java.lang.Override
        public PostServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new PostServiceBlockingStub(channel, callOptions);
        }
      };
    return PostServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static PostServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PostServiceFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<PostServiceFutureStub>() {
        @java.lang.Override
        public PostServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new PostServiceFutureStub(channel, callOptions);
        }
      };
    return PostServiceFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class PostServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void getPost(via.dk.elearn.protobuf.PostUrl request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetPostMethod(), responseObserver);
    }

    /**
     */
    public void getAllPost(via.dk.elearn.protobuf.NewPostRequest request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetAllPostMethod(), responseObserver);
    }

    /**
     */
    public void createNewPost(via.dk.elearn.protobuf.PostModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getCreateNewPostMethod(), responseObserver);
    }

    /**
     */
    public void getById(via.dk.elearn.protobuf.PostId request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetByIdMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetPostMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.PostUrl,
                via.dk.elearn.protobuf.PostModel>(
                  this, METHODID_GET_POST)))
          .addMethod(
            getGetAllPostMethod(),
            io.grpc.stub.ServerCalls.asyncServerStreamingCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.NewPostRequest,
                via.dk.elearn.protobuf.PostModel>(
                  this, METHODID_GET_ALL_POST)))
          .addMethod(
            getCreateNewPostMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.PostModel,
                via.dk.elearn.protobuf.PostModel>(
                  this, METHODID_CREATE_NEW_POST)))
          .addMethod(
            getGetByIdMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                via.dk.elearn.protobuf.PostId,
                via.dk.elearn.protobuf.PostModel>(
                  this, METHODID_GET_BY_ID)))
          .build();
    }
  }

  /**
   */
  public static final class PostServiceStub extends io.grpc.stub.AbstractAsyncStub<PostServiceStub> {
    private PostServiceStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PostServiceStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PostServiceStub(channel, callOptions);
    }

    /**
     */
    public void getPost(via.dk.elearn.protobuf.PostUrl request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetPostMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getAllPost(via.dk.elearn.protobuf.NewPostRequest request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncServerStreamingCall(
          getChannel().newCall(getGetAllPostMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void createNewPost(via.dk.elearn.protobuf.PostModel request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getCreateNewPostMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getById(via.dk.elearn.protobuf.PostId request,
        io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetByIdMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class PostServiceBlockingStub extends io.grpc.stub.AbstractBlockingStub<PostServiceBlockingStub> {
    private PostServiceBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PostServiceBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PostServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public via.dk.elearn.protobuf.PostModel getPost(via.dk.elearn.protobuf.PostUrl request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetPostMethod(), getCallOptions(), request);
    }

    /**
     */
    public java.util.Iterator<via.dk.elearn.protobuf.PostModel> getAllPost(
        via.dk.elearn.protobuf.NewPostRequest request) {
      return io.grpc.stub.ClientCalls.blockingServerStreamingCall(
          getChannel(), getGetAllPostMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.dk.elearn.protobuf.PostModel createNewPost(via.dk.elearn.protobuf.PostModel request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getCreateNewPostMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.dk.elearn.protobuf.PostModel getById(via.dk.elearn.protobuf.PostId request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetByIdMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class PostServiceFutureStub extends io.grpc.stub.AbstractFutureStub<PostServiceFutureStub> {
    private PostServiceFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PostServiceFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PostServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.dk.elearn.protobuf.PostModel> getPost(
        via.dk.elearn.protobuf.PostUrl request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetPostMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.dk.elearn.protobuf.PostModel> createNewPost(
        via.dk.elearn.protobuf.PostModel request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getCreateNewPostMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.dk.elearn.protobuf.PostModel> getById(
        via.dk.elearn.protobuf.PostId request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetByIdMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_POST = 0;
  private static final int METHODID_GET_ALL_POST = 1;
  private static final int METHODID_CREATE_NEW_POST = 2;
  private static final int METHODID_GET_BY_ID = 3;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final PostServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(PostServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_POST:
          serviceImpl.getPost((via.dk.elearn.protobuf.PostUrl) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel>) responseObserver);
          break;
        case METHODID_GET_ALL_POST:
          serviceImpl.getAllPost((via.dk.elearn.protobuf.NewPostRequest) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel>) responseObserver);
          break;
        case METHODID_CREATE_NEW_POST:
          serviceImpl.createNewPost((via.dk.elearn.protobuf.PostModel) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel>) responseObserver);
          break;
        case METHODID_GET_BY_ID:
          serviceImpl.getById((via.dk.elearn.protobuf.PostId) request,
              (io.grpc.stub.StreamObserver<via.dk.elearn.protobuf.PostModel>) responseObserver);
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

  private static abstract class PostServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    PostServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return via.dk.elearn.protobuf.Post.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("PostService");
    }
  }

  private static final class PostServiceFileDescriptorSupplier
      extends PostServiceBaseDescriptorSupplier {
    PostServiceFileDescriptorSupplier() {}
  }

  private static final class PostServiceMethodDescriptorSupplier
      extends PostServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    PostServiceMethodDescriptorSupplier(String methodName) {
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
      synchronized (PostServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new PostServiceFileDescriptorSupplier())
              .addMethod(getGetPostMethod())
              .addMethod(getGetAllPostMethod())
              .addMethod(getCreateNewPostMethod())
              .addMethod(getGetByIdMethod())
              .build();
        }
      }
    }
    return result;
  }
}
