Using project 'D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj'.
Using startup project 'D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj'.
Writing 'D:\programowanie\web\Calories\Calories.Database\obj\Calories.Database.csproj.EntityFrameworkCore.targets'...
dotnet msbuild /target:GetEFProjectMetadata /property:EFProjectMetadataFile=C:\Users\damia\AppData\Local\Temp\tmp3CB0.tmp /verbosity:quiet /nologo D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj
Writing 'D:\programowanie\web\Calories\Calories.Database\obj\Calories.Database.csproj.EntityFrameworkCore.targets'...
dotnet msbuild /target:GetEFProjectMetadata /property:EFProjectMetadataFile=C:\Users\damia\AppData\Local\Temp\tmp425F.tmp;Configuration=mysql /verbosity:quiet /nologo D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj
dotnet build D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj --configuration mysql /verbosity:quiet /nologo
MysqlMigrations\CaloriesContextModelSnapshot.cs(10,6): error CS0579: Duplicate 'DbContext' attribute [D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj]
MysqlMigrations\CaloriesContextModelSnapshot.cs(13,33): error CS0111: Type 'CaloriesContextModelSnapshot' already defines a member called 'BuildModel' with the same parameter types [D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj]

Build FAILED.

MysqlMigrations\CaloriesContextModelSnapshot.cs(10,6): error CS0579: Duplicate 'DbContext' attribute [D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj]
MysqlMigrations\CaloriesContextModelSnapshot.cs(13,33): error CS0111: Type 'CaloriesContextModelSnapshot' already defines a member called 'BuildModel' with the same parameter types [D:\programowanie\web\Calories\Calories.Database\Calories.Database.csproj]
    0 Warning(s)
    2 Error(s)

Time Elapsed 00:00:02.29
Microsoft.EntityFrameworkCore.Tools.CommandException: Build failed.
   at Microsoft.EntityFrameworkCore.Tools.Project.Build()
   at Microsoft.EntityFrameworkCore.Tools.RootCommand.Execute()
   at Microsoft.DotNet.Cli.CommandLine.CommandLineApplication.Execute(String[] args)
   at Microsoft.EntityFrameworkCore.Tools.Program.Main(String[] args)
Build failed.
