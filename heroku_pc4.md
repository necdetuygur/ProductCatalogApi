heroku login
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t productcatalog4api:v1 .
docker tag productcatalog4api:v1 registry.heroku.com/productcatalog4api/web
heroku container:login
docker push registry.heroku.com/productcatalog4api/web
heroku container:release web --app productcatalog4api

api: productcatalog4api.herokuapp.com
app: productcatalog4app.herokuapp.com

Server=sql.bsite.net\\MSSQL2016;Database=productcatalog4_db1;User ID=productcatalog4_db1;Password=Product.741852;Trusted_Connection=False;TrustServerCertificate=True

dotnet ef database update --startup-project Presentation/Api --project Infrastructure/Persistence -c ProjectDbContext
