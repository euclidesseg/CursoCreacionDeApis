using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Aplication
{
    public static  class ServiceExtensions
    {
        /*control+rg para borrar los using innesesarios*/
        public static void AddaplicationLayer(this IServiceCollection services) 
        {
            /*ahora el llamado de matricula de servicios*/
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); /* Esto me permite decirle que registre automatidcamente qu 
                                                                      *los mapeos que haga en la biblioteca de clases*/
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            /* Este tipo de registro se deberia hacer en el startApp de la aplicacion de netcore pero no dependemos de eso ya que usamos 
             * el paquete de dependencias de inyeccion*/

            services.AddMediatR(Assembly.GetExecutingAssembly());
            /*Todas las sentencias de validacion iran dentro de la viblioteca de clase Aplication*/
            
        }
    }
}
