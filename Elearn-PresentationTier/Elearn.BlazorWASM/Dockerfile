FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Elearn.BlazorWASM/Elearn.BlazorWASM.csproj", "Elearn.BlazorWASM/"]
RUN dotnet restore "Elearn.BlazorWASM/Elearn.BlazorWASM.csproj"
COPY . .
WORKDIR "/src/Elearn.BlazorWASM"
RUN dotnet build "Elearn.BlazorWASM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Elearn.BlazorWASM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Elearn.BlazorWASM.dll"]
