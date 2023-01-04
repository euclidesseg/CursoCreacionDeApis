using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Behaviours
{
    /* A continuacion le decimos a esta clase que va a recibir dos tipos uno de peticion y uno de respuesta y que a este se le implementa
     * la interfaz de IPipelineBehavior*/
    public class ValidationBehaviours<Trequest, TResponse> : IPipelineBehavior<Trequest, TResponse> where Trequest : IRequest<TResponse>
        /* Tanto  Irequest como IPipelineBehavior son una interfaz propia de MediaTR*/
    {
        /*creamos el manejador de las peticiones*/
        private readonly IEnumerable<IValidator<Trequest>> _validators;
        /*Ivalidator es del nuguet de fluent validations el media tr nos implementa el patron mediador y el validador nos permite canalizar 
         * las peticiones*/
        public ValidationBehaviours(IEnumerable<IValidator<Trequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(Trequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any()) {/*si hay algun validators implementado hara lo siguiente*/

                var context = new FluentValidation.ValidationContext<Trequest>(request);
                /* creamoe el contexto para que tome la peticion que esta entrando*/
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                /* obtebemos los resultados de las validasiones */
                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                /* recolectamos los errores y los almacenamos en failures como listas de errores*/

                if (failures.Count != 0)/* Si encontro algun error necesitamos lanzar un tipo de excepciones genericas y estas las creamos en 
                                       * la carpeta Exceptions*/

                    throw new Exceptions.ValidationsExceptions(failures);            
            }
            return await next();
        }
    }
}
        /* Creamos un canalzador que nos permite manejar las excepciones qaue nos permite manejar las excepsiones de las regla de negocios
         * que pongamos en nuestra capa aplications*/
