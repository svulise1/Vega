﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Persistence;
using vega.Core;

namespace vega.Persistence
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly vegaDbContext context;
        public UnitOfWork(vegaDbContext context)
        {
            this.context = context;
        }   
        public async  Task Complete()
        {
             await context.SaveChangesAsync();
        }
        
    }
}
