# Containered SQL

Run SQL Server in a Docker container, and setup EF to connect.

## Run SQL Server Container

```bash
docker run \
    -e "ACCEPT_EULA=Y" \
    -e 'MSSQL_SA_PASSWORD=P@$$Word1234' \
    -p 1433:1433 \
    --name DevSql \
    --hostname DevSql \
    -d mcr.microsoft.com/mssql/server:2022-latest
```

## Connection String

[appsettings.Development.json](./appsettings.Development.json)

```json
{
  "ConnectionStrings": {
    "Db": "Server=localhost,1433;Encrypt=Mandatory;TrustServerCertificate=True;User=sa;Password=P@$$Word1234;Database=ContaineredDb"
  }
}
```

## Azure Data Studio - Connection Details

Property | Value
---------|------
Connection Type | Microsoft SQL Server
Input Type | Parameters
Server | localhost
Authentication type | SQL Login
User name | sa
Password | P@$$Word1234
Remember password | y
Encrypt | Mandatory
Trust server certificate | True
Name (optional) DevSql