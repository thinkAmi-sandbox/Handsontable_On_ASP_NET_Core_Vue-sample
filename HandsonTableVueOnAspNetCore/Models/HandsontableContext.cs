using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HandsonTableVueOnAspNetCore.Models
{
    public class HandsontableContext : DbContext
    {
        public HandsontableContext(DbContextOptions<HandsontableContext> options) : base(options) {}

        public DbSet<Customer> Customers { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                    .AddConsole();
            });
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(MyLoggerFactory);
        }
    }
}