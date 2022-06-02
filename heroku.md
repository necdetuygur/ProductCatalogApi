heroku login
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi -f $(docker images -aq)
docker build -t aipu:v1 .
docker tag aipu:v1 registry.heroku.com/aipu/web
heroku container:login
docker push registry.heroku.com/aipu/web
heroku container:release web --app aipu
heroku logs --tail --app aipu
