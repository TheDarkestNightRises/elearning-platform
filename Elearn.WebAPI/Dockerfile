FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Elearn.WebAPI/Elearn.WebAPI.csproj", "Elearn.WebAPI/"]
RUN dotnet restore "Elearn.WebAPI/Elearn.WebAPI.csproj"
COPY . .
WORKDIR "/src/Elearn.WebAPI"
RUN dotnet build "Elearn.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Elearn.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Elearn.WebAPI.dll"]
