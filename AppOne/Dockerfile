FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AppOne/AppOne.csproj", "AppOne/"]
RUN dotnet restore "AppOne/AppOne.csproj"
COPY . .
WORKDIR "/src/AppOne"
RUN dotnet build "AppOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppOne.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppOne.dll"]