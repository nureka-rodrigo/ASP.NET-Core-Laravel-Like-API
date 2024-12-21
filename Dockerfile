FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORT=8000
EXPOSE 8000
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreLaravelAPI.dll"]