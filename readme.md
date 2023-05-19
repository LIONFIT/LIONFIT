## LIONFIT APP

## MIGRATION

dotnet ef migrations add InitialMigration --context LIONFIT.Data.ApplicationDbContext -o "C:\Users\51970\Desktop\LIONFIT\Data\Migrations"

dotnet ef migrations add AgregandoTablas2Migration --context LIONFIT.Data.ApplicationDbContext -o "C:\Users\gianc\LIONFIT\Data\Migrations"


//comando para poder actulizar el dotnet
dotnet tool update --global dotnet-ef --version 7.0.3

// comando para una migracion 
dotnet ef database update