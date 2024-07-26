# ShopApp

*ShopApp* is an e-commerce website built with the ASP.NET Core framework. In this project:

* Preferred [VS Code](https://code.visualstudio.com/download) (*C# Dev Kit*, *Auto Rename Tag*, and *CSharpier* extensions are recommended).

* Version (.NET):
```powershell
dotnet --version
7.0.202
``` 
* SDKs (.NET):
```powershell
dotnet --list-sdks
7.0.202 [C:\Program Files\dotnet\sdk]
```
* Packages used in projects:

  **ShopApp**
  - Microsoft.EntityFrameworkCore.Design - 7.0.20

  **Entities**
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore - 7.0.20

  **Repositories**
  - Microsoft.EntityFrameworkCore - 7.0.20
  - Microsoft.EntityFrameworkCore.Sqlite - 7.0.20

  **Services**
  - AutoMapper.Extensions.Microsoft.DependencyInjection - 12.0.1

  For the packages, visit [NuGet](https://www.nuget.org/).

## Getting Started

### Installing & Running

1) Clone the project to your PC:

```powershell
git clone https://github.com/doganseyfisen/ASP.NET-ShopApp.git
```

2) Then check the files/folders under the repo:
```powershell
PS C:\Users\dogan\Desktop> cd .\ASP.NET-ShopApp\
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp> dir


    Directory: C:\Users\dogan\Desktop\ASP.NET-ShopApp


Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
d-----        26/07/2024     23:51                .vscode
d-----        26/07/2024     23:51                Entities
d-----        26/07/2024     23:51                Repositories
d-----        26/07/2024     23:51                Services
d-----        26/07/2024     23:51                ShopApp
-a----        26/07/2024     23:51           7934 .gitignore
-a----        26/07/2024     23:51           2403 Shop.sln
```

3) To run *ShopApp* and see how it looks, you have to go to:
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp> cd .\ShopApp\
```
Since *ShopApp* is the name of our web project:
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp> pwd

Path
----
C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp
```

4) Then, before running, you may want to build:
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp> dotnet build
MSBuild version 17.5.0+6f08c67f3 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  Entities -> C:\Users\dogan\Desktop\ASP.NET-ShopApp\Entities\bin\Debug\net7.0\
  Entities.dll
  Repositories -> C:\Users\dogan\Desktop\ASP.NET-ShopApp\Repositories\bin\Debug
  \net7.0\Repositories.dll
  Services -> C:\Users\dogan\Desktop\ASP.NET-ShopApp\Services\bin\Debug\net7.0\
  Services.dll
  ShopApp -> C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp\bin\Debug\net7.0\Sh
  opApp.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.98
```

5) One **important** thing is creating a database. Open your IDE, then see `appsettings.json`. You should change the `Data Source = C:\\Users\\dogan\\MVC\\ProductDb.db`, to something that best suits your usage. Otherwise, it could cause issues.
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "sqlconnection": "Data Source = C:\\Users\\dogan\\MVC\\ProductDb.db"
  }
}
``` 

6) After this change, you should run the following commands:
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp> dotnet ef migrations add <migration name> 
``` 
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp> dotnet ef database update 
``` 

7) Finally, you can run it by entering `dotnet run` or `dotnet watch`:
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp> dotnet run
```
or
```powershell
PS C:\Users\dogan\Desktop\ASP.NET-ShopApp\ShopApp> dotnet watch
```
If the browser doesn't open automatically, you should click the localhost link in the terminal output:
```powershell
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5287
```

### Useful Commands

In the console, there are many useful commands. For more information, you can search on the internet or ask GPT. Here are some of the commands I mostly used:

* To make migrations:
```powershell
dotnet ef migrations add <migration name>
```
* To update the database:
```powershell
dotnet ef database update
```
* To drop the database:
```powershell
dotnet ef database drop
```
* SQLite (be sure you are in the directory where `<your db name>.db` file is located):
```powershell
sqlite3 <your db name>
```
```powershell
sqlite> .tables
```
```powershell
sqlite> select * from <table name>
```
```powershell
sqlite> .mode box
```
```powershell
sqlite> .system cls
```
```powershell
sqlite> .exit
```

* To see packages:
```powershell
dotnet list package
```

### User Names - Passwords
* `Admin` - `Admin+12345`
* `test` - `Test12345*`

## Author

* **Dogan Seyfi Sen** - [LinkedIn](https://linkedin.com/in/doganseyfisen)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Next Steps I Consider To Do 

* User profile page
* User comments
* API
* Better front-end experience for users
