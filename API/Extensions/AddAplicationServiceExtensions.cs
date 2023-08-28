using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

namespace API.Extensions;


public static class AddAplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options=>
        options.AddPolicy("CorsPolicy",builder=>
        {
            builder.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        }));
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }

}