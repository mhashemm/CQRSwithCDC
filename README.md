To run the app you must have Docker installed and run the following commands.

```
docker compose up --build
```
```
docker exec -it db /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P P@ssW0rd! -i ./CreateDbWrite.sql
```
Output should be:
```
  # Changed database context to 'master'.
  # Changed database context to 'CQRSwithCDC_Write'.
  # Changed database context to 'master'.
  # Changed database context to 'CQRSwithCDC_Write'.
  # Job 'cdc.CQRSwithCDC_Write_capture' started successfully.
  # Job 'cdc.CQRSwithCDC_Write_cleanup' started successfully.
```

```
docker exec -it connect bash
```
```
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '{ "name": "cqrs-connector","config": {"connector.class": "io.debezium.connector.sqlserver.SqlServerConnector","database.hostname": "db","database.port": "1433","database.user": "sa","database.password": "P@ssW0rd!","database.dbname": "CQRSwithCDC_Write","database.server.name": "CQRSwithCDC_Write","table.include.list": "dbo.Students,dbo.Courses,dbo.Disenrollments,dbo.Enrollments","database.history.kafka.bootstrap.servers": "kafka:9092","database.history.kafka.topic": "dbhistory.CQRSwithCDC_Write" } }'
```
```
curl -H "Accept:application/json" connect:8083/connectors/
```
Output should be:
```
["cqrs-connector"]
```