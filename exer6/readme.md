dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
psql -U postgres -c "CREATE DATABASE \"Adventureworks\";"
psql -d Adventureworks -f install.sql -U postgres
