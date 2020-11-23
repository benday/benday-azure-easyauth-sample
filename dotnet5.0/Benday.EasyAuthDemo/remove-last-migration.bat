set base=%cd%
cd src\Benday.EasyAuthDemo.Api

dotnet ef migrations remove

cd %base%