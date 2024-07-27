
using Microsoft.EntityFrameworkCore;

namespace GooderReads.ApiService
{
    public class Migrator : BackgroundService
    {
        private readonly IServiceProvider sp;

        public Migrator(IServiceProvider sp)
        {
            this.sp = sp;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = sp.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<GooderReadsContext>();
            await ctx.Database.MigrateAsync();
        }
    }
}
