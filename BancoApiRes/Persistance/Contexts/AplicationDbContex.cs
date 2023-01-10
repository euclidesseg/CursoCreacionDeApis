using Aplication.Interfaces;
using Domain.Common;
/* domain se inporta ya que estamos haciendo uso de la clase AuditableBaseEntity*/
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class AplicationDbContex : DbContext
    {
        private readonly IDateTimeService _dateTime;
        public AplicationDbContex(DbContextOptions<AplicationDbContex> options, IDateTimeService dateTime) :base(options)
        /* se le dice al constructor que las dbcontext de esta aplciacion(AplicationDbContex) se llamaran option y esto va a eredar
         * de base.option */
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            /* por buena practica ejecutamos esto y es devido al comportamiento de seguimiento, QueryTrackingBehavior controla
             * que entitiframework core va a mantener toda la in formacion dobre una instancia de entidad sobre un rastreador de cambios
             * entonces necesito crear una interfaz llamada IDateTimeService*/
            _dateTime = dateTime;
        }
        public DbSet<Cliente> Clientes { get; set; }/* aqui hago referencia a la entidad cliente en la biblioteca Domain*/
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State) 
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        /*este NowUtc hace referencia al NowUtc que creamos en la clase ISTimeServices*/
                        break;
                    case EntityState.Modified:
                        entry.Entity.lastModifiedBy = _dateTime.NowUtc; 
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
