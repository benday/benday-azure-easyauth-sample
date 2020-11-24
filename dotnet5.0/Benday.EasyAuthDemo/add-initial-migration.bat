set base=%cd%
cd src\Benday.EasyAuthDemo.Api

dotnet ef migrations add InitialSetup

cd %base%

ECHO sorting migration properties
dotnet migration-sorter\efcoreutil.dll sortmigrationproperties /directory:src\Benday.EasyAuthDemo.Api\Migrations /migrationname:InitialSetup /updatefile