heroku login
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t nkhu:v1 .
docker tag nkhu:v1 registry.heroku.com/nkhu/web
heroku container:login
docker push registry.heroku.com/nkhu/web
heroku container:release web --app nkhu

productcatalog@proton.me:Product.741852

api: nkhu.herokuapp.com
app: ludd.herokuapp.com