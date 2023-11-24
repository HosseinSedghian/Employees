using Employees.Services;

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
            }

            var app = builder.Build();
            {
                app.MapControllers();
                app.Run();
            }
        }
    }
}
