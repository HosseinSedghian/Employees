using Employees.Data;
using Employees.Services;
using Microsoft.EntityFrameworkCore;

namespace Employees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.Sleep(20000);
            string connectionString = string.Empty;
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddControllers();
                builder.Services.AddScoped<IEmployeeService, EmployeeService>();

                // Connection String
                string db_server = Environment.GetEnvironmentVariable("DB_SERVER")!;
                string db_name = Environment.GetEnvironmentVariable("DB_NAME")!;
                string user_id = Environment.GetEnvironmentVariable("USER_ID")!;
                string password = Environment.GetEnvironmentVariable("PASSWORD")!;
                connectionString =
                    $"Data Source={db_server};Initial Catalog={db_name};User Id={user_id};Password={password};TrustServerCertificate=True";
                
                builder.Services.AddDbContext<EmployeeContext>(options =>
                    options.UseSqlServer(connectionString)
                );
            }
            var app = builder.Build();
            {
                var logger = app.Logger;
                logger.LogInformation("\n======================\n" + connectionString + "\n======================\n");
                app.MapControllers();
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
                    dbContext.Database.Migrate();
                }
                app.Run();
            }
        }

    }
}
