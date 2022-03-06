FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AppTwo/AppTwo.csproj", "AppTwo/"]
RUN dotnet restore "AppTwo/AppTwo.csproj"
COPY . .
WORKDIR "/src/AppTwo"
RUN dotnet build "AppTwo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppTwo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppTwo.dll"]