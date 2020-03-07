docker build -t sdg-all-small .

docker tag sdg-all-small registry.heroku.com/sdg-all-small/web

docker push registry.heroku.com/sdg-all-small/web

heroku container:release web -a sdg-all-small