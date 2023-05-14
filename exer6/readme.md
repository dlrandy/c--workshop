dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
psql -U postgres -c "CREATE DATABASE \"Adventureworks\";"
psql -d Adventureworks -f install.sql -U postgres

dotnet add package Microsoft.EntityFrameworkCore.tools
dotnet tool install --global dotnet-ef

// database first
dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=postgres;Database=Adventureworks" Npgsql.EntityFrameworkCore.PostgreSQL -o models/ --schema "production"

dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=postgres;Database=globalfactory2021" Npgsql.EntityFrameworkCore.PostgreSQL -o GlobalFactory2021

//code first 
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add MyFirstMigration -c globalfactory2021Context

// apply migration
dotnet ef database update -c globalfactory2021context

// add new migration
dotnet ef migrations add AddManufacturerFoundedDate -c globalfactory2021Context

// apply migration
dotnet ef database update -c globalfactory2021context

// To undo this action
dotnet ef migrations remove -c globalfactory2021context


<!-- Migration Steps -->
1. Added the new property and model builder changes
2. Created migration files
3. Updated a database with that migration file

<!-- Undo migration steps -->
1. Rolling back database changes(updating the database to the last successful migration)
2. Removing the migration file
3. Removing model builder changes

Selectively apply any migation you want.
Apply the previous migration
1. dotnet ef database update MyFirstMigration -c globalfactory2021context


// a custom migration script for big and complex database
dotnet ef migrations script -c globalfactory2021context

// transfer migration to script
dotnet ef migrations script -c globalfactory2021context -o sql.sh





