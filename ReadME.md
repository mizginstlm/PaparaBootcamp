
 #  PAPARA BOOTCAMP API
In my projects, I've primarily utilized Azure Data Studio, Docker, and VS Code due to the possibility of exclusively using MacOS. I downloaded the packages using NuGet and predominantly relied on the command line for most operations. These details hold true for the latest commit I made as well as all my previous homeworks.

# Starting SQL server
```powershell

docker run -e 'ACCEPT_EULA=Y' microsoft/mssql-server-linux -e 'MSSQL_SA_PASSWORD=[yourpassword]' -p 1433:1433 -v sqlvolume:/var/opt/mssql  -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest 
```
## Setting the connection string to secret manager
```powershell
dotnet user-secrets set 'ConnectionStrings:DefaultConnection' 'Server=localhost; Database=dotnet-steps ;User Id=SA; Password=[yourpassword]; Trusted_Connection=false; TrustServerCertificate=true;'
``` 

#Using login and connect database by typing your password from terminal or cmd and continue to make connections is more secure(I recommend it even if I don't use it for now).


Database commands that I used in macos os:

```powershell
dotnet ef migrations add [name]
```
```powershell
dotnet ef database update
```
To run and build API I used "dotnet watch run" command in macos. But before these you may need to go into api directory with "cd" command.

When developing in macos sometimes vscode doesnt integrate new changes so you should run and debug. Then it would work without uneccesary log errors.

Use commands in NuGet website to install packages or some libraries.

