using HotelManagementAPI.Contracts;
using HotelManagementAPI.Repository;
using Serilog;

namespace HotelManagementAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigureHostBuilder host)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IHotelsRepository, HotelsRepository>();


            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    b => b.AllowAnyHeader()
                          .AllowAnyOrigin()
                          .AllowAnyMethod());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            host.UseSerilog(
                (ctx, lc) => lc.WriteTo
                           .Console().ReadFrom
                           .Configuration(ctx.Configuration));

            return services;
        }
    }
}
