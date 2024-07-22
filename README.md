# SupplyTracker with Entity Framework
Authors:

Thien Nguyen

Brandon Mitzel

## Getting started

- Visual Studio 2022
- .Net 8
- [Supply Tracker database](SupplyTracker.sql) installed
- Supply Tracker database connection string in appsettings.json

### Step one - Run the query to generate the database in the sql server
You can generate the database by using SQL Server Object Explorer in VS 2022 or using SQL Server Management Studio.

### Step two - install package needed for entity framework
Right click on the project -> Manage Nuget Packages -> Browse
Then install these packages below
```bash
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design
```

### Step three - generate models from the database
Click on Tools -> nuget package manager -> package manager console
Type the command below to generate the models
```csharp
Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SupplyTracker' Microsoft.EntityFrameworkCore.SqlServer
```

You may need to change the DB connection string located in the SupplyTrackerContext class.
By default, it points to mssqllocaldb. You can change it to your own database.
```csharp
optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SupplyTracker");
```
