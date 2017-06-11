using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Persistence;
using Vega.Core;
using Vega.Models;

namespace Vega.Persistence
{
    public  class VechileRepo : IVechileRepo
    {
        private readonly VegaDbContext context;
        public VechileRepo(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vechile> GetVechile(int id, bool Includerelated = true)
        {
            if (!Includerelated )
            {
                return await context.Vechiles.FindAsync(id);
            }

            return await context.Vechiles.Include(v => v.Features).
               ThenInclude(vf => vf.Feature).
               Include(v => v.Model).
               ThenInclude(m => m.Make).
               SingleOrDefaultAsync(v => v.Id == id);
        }

        public  void AddVechile(Vechile vechile)
        {
            context.Vechiles.Add(vechile);
        }

        public void RemoveVechile(Vechile vechile)
        {
            context.Remove(vechile);
        }
    }
}
