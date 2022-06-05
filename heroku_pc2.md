heroku login
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t productcatalog2api:v1 .
docker tag productcatalog2api:v1 registry.heroku.com/productcatalog2api/web
heroku container:login
docker push registry.heroku.com/productcatalog2api/web
heroku container:release web --app productcatalog2api

api: productcatalog2api.herokuapp.com
app: productcatalog2app.herokuapp.com

Server=sql.bsite.net\\MSSQL2016;Database=productcatalog2_db1;User ID=productcatalog2_db1;Password=Product.741852;Trusted_Connection=False;TrustServerCertificate=True

dotnet ef database update --startup-project Presentation/Api --project Infrastructure/Persistence -c ProjectDbContext
