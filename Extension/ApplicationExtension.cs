using AppAPI.Data;
using AppAPI.Interfaces;
using AppAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Extension
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplictionServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenServices, TokenServices>();
            return services;
        }
    }
}
