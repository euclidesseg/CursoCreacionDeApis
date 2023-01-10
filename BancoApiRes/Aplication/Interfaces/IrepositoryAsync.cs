using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    /*esta clase implementara un repositorio*/
    public interface IrepositoryAsync<T> : IRepositoryBase<T> where T : class
        /* esta clase hereda de IrepositoryAsyncBase se le pasa como parametro un operador generico 
         * el cual sera de una clase*/
    {
    }
    /* ahora ocupamos el nuguet de ardalis para no escribir todo el patron repository
     * esta clase indica que va a leer dodo el IRepositoryBase */
    public interface IReadRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {

    }
}
