using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Exceptions
{
    public class ValidationsExceptions : Exception
    {
        public ValidationsExceptions() : base("Se han producido Uno o mas errores de validación")
        { 
            Errors = new List<string>(); /* Recopilamos esos errores como listado de strings*/
        }
        public List<string> Errors { get;} 

        public ValidationsExceptions(IEnumerable<ValidationFailure> failures) : this()
        /* IEnumerable Esta interface proporciona un método GetEnumerator()
         * que permite recorrer los elementos de la colección de manera secuencial, uno a uno.*/
        {
            foreach (var failure in failures)/* Recojemos los errores de la clase validationException y los agregamos a la variable errors*/
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
