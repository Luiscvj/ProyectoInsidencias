using Aplicacion.UnitOfWork;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

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


    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
       services.AddApiVersioning(options =>
       {
            options.DefaultApiVersion = new ApiVersion(1,0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader =ApiVersionReader.Combine
            (

             new QueryStringApiVersionReader("v"),
             new HeaderApiVersionReader("X-Version")

            );
        
       });
    }



   
}