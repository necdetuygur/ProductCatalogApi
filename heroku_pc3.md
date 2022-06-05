heroku login
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t productcatalog3api:v1 .
docker tag productcatalog3api:v1 registry.heroku.com/productcatalog3api/web
heroku container:login
docker push registry.heroku.com/productcatalog3api/web
heroku container:release web --app productcatalog3api

api: productcatalog3api.herokuapp.com
app: productcatalog3app.herokuapp.com

Server=sql.bsite.net\\MSSQL2016;Database=productcatalog3_db1;User ID=productcatalog3_db1;Password=Product.741852;Trusted_Connection=False;TrustServerCertificate=True

dotnet ef database update --startup-project Presentation/Api --project Infrastructure/Persistence -c ProjectDbContext
