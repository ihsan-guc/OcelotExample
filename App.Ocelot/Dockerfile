FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["App.Ocelot/App.Ocelot.csproj", "App.Ocelot/"]
RUN dotnet restore "App.Ocelot/App.Ocelot.csproj"
COPY . .
WORKDIR "/src/App.Ocelot"
RUN dotnet build "App.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Ocelot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Ocelot.dll"]