FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
COPY ./Presentation/Api/appsettings.json ./appsettings.json
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Api.dll