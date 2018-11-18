FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithAspNetDockers/db/migrations/ /home/database/
COPY ./RestWithAspNetDockers/db/dataset/ /home/database/
COPY ./RestWithAspNetDockers/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh