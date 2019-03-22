namespace CodeFirst
{
    using EFCodeFirst.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    public class StartUp
    {
        public static void Main()
        {
            LoggerFactory SqlCommandLoggerFactory = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true)
            });
            string connectionString = "Server=localhost,8976;Database=BlogDb;Trusted_Connection=True;";
            DbContextOptionsBuilder<BlogDbContext> optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseSqlServer(connectionString, s => s.MigrationsAssembly("EFCodeFirst.Infrastructure"))
                .UseLoggerFactory(SqlCommandLoggerFactory)
                .EnableSensitiveDataLogging();

        }
    }
}
