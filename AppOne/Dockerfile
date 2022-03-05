
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

COPY /*.csproj .

RUN dotnet restore

COPY . ./

RUN dotnet publish --no-restore -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT ["dotnet", "AppOne.dll"]
