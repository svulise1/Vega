using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Persistence;
using Vega.Core;

namespace Vega.Persistence
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly VegaDbContext context;
        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
        }   
        public async  Task Complete()
        {
             await context.SaveChangesAsync();
        }
        
    }
}
