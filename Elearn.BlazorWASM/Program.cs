using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Elearn.BlazorWASM;
using Elearn.BlazorWASM.Auth;
using Elearn.HttpClients.Http;
using Elearn.HttpClients.Service;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IPostService, PostHttpClient>();
builder.Services.AddScoped<ICommentService, CommentHttpClient>();
builder.Services.AddScoped<IAuthService, JwtHttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
AuthorizationPolicies.AddPolicies(builder.Services);


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7219") });
builder.Services.AddMudServices();

await builder.Build().RunAsync();