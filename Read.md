#instaling packages with proper version

dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.1.26 dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.1.26 dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.1.26

#migrations
dotnet ef migrations add Initial
#remove migratino
dotnet ef migrations remove

#revert db
dotnet ef migrations list
dotnet ef database update 20231214112734_Seeding
dotnet ef database update 0

#update database
dotnet ef migrations add Seeding
dotnet ef database update

#dotnet dotnet clean dotnet build

#droping db
dotnet ef database drop
dotnet ef database update
<!-- Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false), -->

# dotnet add package Newtonsoft.Json --version 6.1.26
