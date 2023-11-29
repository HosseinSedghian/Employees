using Employees.Data;
using Employees.Services;
using Microsoft.EntityFrameworkCore;

namespace Employees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddControllers();
                builder.Services.AddScoped<IEmployeeService, EmployeeService>();
                string db_server = Environment.GetEnvironmentVariable("DB_SERVER")!;
                string db_name = Environment.GetEnvironmentVariable("DB_NAME")!;
                string user_id = Environment.GetEnvironmentVariable("USER_ID")!;
                string password = Environment.GetEnvironmentVariable("PASSWORD")!;
                string connectionString =
                    $"Data Source={db_server};Initial Catalog={db_name};User Id={user_id};Password={password};TrustServerCertificate=True";
                //builder.Services.AddDbContext<EmployeeContext>(options =>
                //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                builder.Services.AddDbContext<EmployeeContext>(options =>
                    options.UseSqlServer(connectionString)
                );
            }
            var app = builder.Build();
            {
                app.MapControllers();
                app.Run();
            }
        }

    }
}
