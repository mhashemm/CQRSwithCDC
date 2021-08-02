### To run the app you need Docker installed and run the following commands.

```
docker compose up connect --build
```
In a new window run the following commands:
```
docker exec -it cqrswithcdc-db /opt/mssql-tools/bin/sqlcmd -S db -U sa -P P@ssW0rd! -i ./CreateDbs.sql
```
```
docker exec -it cqrswithcdc-kafka bash -c "bin/kafka-topics.sh --create --bootstrap-server kafka:9092 --topic CQRSwithCDC_Write;bin/kafka-topics.sh --create --bootstrap-server kafka:9092 --topic CQRSwithCDC_Write.dbo.Students;bin/kafka-topics.sh --create --bootstrap-server kafka:9092 --topic CQRSwithCDC_Write.dbo.Courses;bin/kafka-topics.sh --create --bootstrap-server kafka:9092 --topic CQRSwithCDC_Write.dbo.Enrollments;bin/kafka-topics.sh --create --bootstrap-server kafka:9092 --topic CQRSwithCDC_Write.dbo.Disenrollments;"
```
```
docker exec -it cqrswithcdc-connect bash
```
```
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '{ "name": "cqrs-connector","config": {"connector.class": "io.debezium.connector.sqlserver.SqlServerConnector","database.hostname": "db","database.port": "1433","database.user": "sa","database.password": "P@ssW0rd!","database.dbname": "CQRSwithCDC_Write","database.server.name": "CQRSwithCDC_Write","database.history.kafka.bootstrap.servers": "kafka:9092","database.history.kafka.topic": "dbhistory.CQRSwithCDC_Write" } }'
```
Then press CTRL+D and run the following
```
docker compose up consumers --build
```