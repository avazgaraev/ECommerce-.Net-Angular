using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Solution1.Persistence.Contexts;


namespace Solution1.Persistence
{
    public static class PersistenceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Solution1DbContext>(options=>options.UseNpgsql("User Id = root;Password=mrPassword;Host=localhost:Port=5432;Database=myDataBase"));
        }
    }
}
