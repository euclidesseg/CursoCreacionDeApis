using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    /* Esta interfaz permite hacer el seguimiento o agregar el createby y el asmodifigy es decir, las fechas de cuando fue creado
     * y la fecha de cuando fuer modificado*/
    public interface IDateTimeService
    {
        /*esta interfaz la voy a inyectar como una dependencia atravez del ccontex*/
        DateTime NowUtc { get; }
    }
}
