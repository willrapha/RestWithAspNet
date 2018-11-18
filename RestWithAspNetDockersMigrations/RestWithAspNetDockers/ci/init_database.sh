#Comando responsavel por pegar nossas migrations do Evolve
for i in `find /home/database/ -name "*.sql" | sort --version-sort`; do mysql -udocker -pdocker rest_udemy < $i; done;