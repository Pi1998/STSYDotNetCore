# STSYDotNetCore
db first(manual, auto)
- efcore

dotnet ef dbcontext scaffold "Server=localhost;Database=STSYDotNetCore;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f


code first
(db later)


