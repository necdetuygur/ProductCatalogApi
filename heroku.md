FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Api.dll


docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t aipu:v1 .
docker run -p 81:80 aipu:v1

docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t aipu:v1 .
docker tag aipu:v1 registry.heroku.com/aipu/web
heroku container:login
docker push registry.heroku.com/aipu/web
heroku container:release web --app aipu

heroku logs --tail --app aipu


dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
dotnet ef migrations add m1 --startup-project Presentation/Api --project Infrastructure/Persistence -c ProjectDbContext
dotnet ef migrations add m1 -s Presentation/Api -p ProjectDbContext
dotnet ef migrations add m1 --project Infrastructure/Persistence/Persistence.csproj
dotnet ef database update --project Infrastructure/Persistence/Persistence.csproj
dotnet run --project Presentation/Api/Api.csproj

Server=sql.bsite.net\\MSSQL2016;Database=ecommerceproject_db2;User ID=ecommerceproject_db2;Password=Ecommerce.78645;Trusted_Connection=False;TrustServerCertificate=True
h: sql.bsite.net\MSSQL2016
u: ecommerceproject_db2
d: ecommerceproject_db2
p: Ecommerce.78645

freeasphosting.net
u: ecommerceproject
p: Ecommerce.78645


https://aipu.herokuapp.com/swagger