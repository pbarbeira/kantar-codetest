#!/bin/bash
/opt/mssql/bin/sqlservr &

echo "Waiting for SQL Server to start..."
sleep 20  # Wait for SQL Server to initialize

for file in /Scripts/*.sql; do
    echo "Executing $file..."
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -i "$file"
done

wait

