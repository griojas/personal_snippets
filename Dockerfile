# Sample of Docker usage to build a data collector microservice using ruby/sinatra

FROM ruby:2.3.1-alpine

WORKDIR /cdn-data-collectors

EXPOSE 80

ADD Gemfile  /cdn-data-collectors/
ADD Gemfile.lock /cdn-data-collectors/
ADD config.ru /cdn-data-collectors/
ADD Procfile /cdn-data-collectors/
ADD Rakefile /cdn-data-collectors/
ADD /config /cdn-data-collectors/config/
ADD /db /cdn-data-collectors/db
ADD /lib /cdn-data-collectors/lib

RUN buildDeps='build-base libstdc++ mariadb-dev' \
 && runDeps='tzdata libstdc++ bash mariadb-client-libs curl' \
 && apk add -U $buildDeps \
 && gem install bundler \
 && bundle install \
 && apk del -r $buildDeps \
 && apk add -U $runDeps

CMD rackup --host 0.0.0.0 -p 80