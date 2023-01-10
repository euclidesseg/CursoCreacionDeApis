using Aplication.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Fautres.Clientes.Comands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<Response<int>>
        /* Cuando alguien atravez de los contoladores de la api llame al comando atravez de IRequest necesitamos crear el
         * mediador para eso creamos en Wrappers la clase Response para indicar donde esta Response */
    {

        /* estamos usando la entidad para traer todos estos campos que son los que realmente necesitamos para llenar un cliente 
         * no necesitamos lo que esta en AuditableBaseEntity en caso que si mapiariamos todo lo de auditable baseentity*/
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }


    public class createClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
        /* se esta inplementando la calse Response y se le inserta este id porque esta clase inplementada esta pidiendo un paametro
         * ese parametro es generico y nosotros le estamos pasando un int ese sera el id que insertaremos cuando creemos nuestro cliente
         * atravez de ese id podremos capturar el recurso*/
    {
        /* cuando nosotros llamemos la  clase createClientComand atravez del controlador lo que pasara es que automaticamente va a 
         * ejecutar la clase mediadora(createClientCommandHandler)y necesitamos guardar 
         * los datos dentro de un repositorio de datos y para eso implementaremos una persistencia para conexion a base de datos*/
        public Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
