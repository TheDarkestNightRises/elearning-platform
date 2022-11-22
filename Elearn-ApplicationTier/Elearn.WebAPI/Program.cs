using System.Text;
using Elearn.Application.Logic;
using Elearn.Application.LogicInterfaces;
using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Client;
using Elearn.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Shared.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
builder.Services.AddGrpc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<ILectureService, LectureGrpcClient>();
builder.Services.AddScoped<ICommentService, CommentGrpcClient>();
builder.Services.AddScoped<IUserService, UserGrpcClient>();
builder.Services.AddScoped<IQuestionService, QuestionGrpcClient>();
builder.Services.AddScoped<ICommentLogic, CommentLogic>();
builder.Services.AddScoped<ILectureLogic, LectureLogic>();
builder.Services.AddScoped<IAuthLogic, AuthLogic>();
builder.Services.AddScoped<IQuestionLogic,QuestionLogic>();
builder.Services.AddGrpcClient<CommentGrpcClient>();
// builder.Services.AddGrpcClient<LectureGrpcClient>();
builder.Services.AddGrpcClient<UserGrpcClient>();
builder.Services.AddGrpcClient<QuestionGrpcClient>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
AuthorizationPolicies.AddPolicies(builder.Services);


var app = builder.Build();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseRouting();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<CommentGrpcClient>().EnableGrpcWeb();
    // endpoints.MapGrpcService<LectureGrpcClient>().EnableGrpcWeb();
    endpoints.MapGrpcService<UserGrpcClient>().EnableGrpcWeb();
    endpoints.MapGrpcService<QuestionGrpcClient>().EnableGrpcWeb();

});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();