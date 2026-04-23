FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY JobFinder/JobFinder.csproj JobFinder/
RUN dotnet restore JobFinder/JobFinder.csproj

COPY JobFinder/. JobFinder/
WORKDIR /src/JobFinder
RUN dotnet publish JobFinder.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

COPY --from=build /app/publish .
RUN mkdir -p /app/Data

EXPOSE 10000

ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://+:${PORT:-10000} dotnet JobFinder.dll"]
