using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity
        /* aqui estamos creando una entidad base para que todas las demas entidades que vallamos creando vallan eredando de estas*/
    {
        public virtual int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime lastModifiedBy { get; set; }
    }
}
