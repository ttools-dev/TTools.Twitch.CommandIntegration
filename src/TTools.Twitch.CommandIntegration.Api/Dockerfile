FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TTools.Twitch.CommandIntegration.Api/TTools.Twitch.CommandIntegration.Api.csproj", "TTools.Twitch.CommandIntegration.Api/"]
RUN dotnet restore "src/TTools.Twitch.CommandIntegration.Api/TTools.Twitch.CommandIntegration.Api.csproj"
COPY . .
WORKDIR "/src/TTools.Twitch.CommandIntegration.Api"
RUN dotnet build "TTools.Twitch.CommandIntegration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TTools.Twitch.CommandIntegration.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TTools.Twitch.CommandIntegration.Api.dll"]
