dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
psql -U postgres -c "CREATE DATABASE \"Adventureworks\";"
psql -d Adventureworks -f install.sql -U postgres

dotnet add package Microsoft.EntityFrameworkCore.tools
dotnet tool install --global dotnet-ef

dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=postgres;Database=Adventureworks" Npgsql.EntityFrameworkCore.PostgreSQL -o models/ --schema "production"

dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=postgres;Database=globalfactory2021" Npgsql.EntityFrameworkCore.PostgreSQL -o GlobalFactory2021

//code first 
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add MyFirstMigration -c globalfactory2021Context

dotnet ef database update -c globalfactory2021context
