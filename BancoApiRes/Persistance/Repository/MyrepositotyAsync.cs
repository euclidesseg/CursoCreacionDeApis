using Aplication.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    /*esta clase es nuestro patron repositorio qu hereda de irepositoryasync*/
    public class MyrepositotyAsync<T> : RepositoryBase<T>, IrepositoryAsync<T> where T : class
    {
        private readonly AplicationDbContex dbContex;
        public MyrepositotyAsync(AplicationDbContex dbContex) : base(dbContex)
        {
            this.dbContex = dbContex;
        }
    }
  
}
