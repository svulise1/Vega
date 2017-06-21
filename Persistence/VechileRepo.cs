using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Persistence;
using vega.Core;
using vega.Models;

namespace vega.Persistence
{
    public  class VechileRepo : IVechileRepo
    {
        private readonly vegaDbContext context;
        public VechileRepo(vegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vechile> GetVechile(int id, bool includeRelated = true)
        {


            if (!includeRelated)
                return await context.Vechiles.FindAsync(id);

            return await context.Vechiles
              .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
              .Include(v => v.Model)
                .ThenInclude(m => m.Make)
              .SingleOrDefaultAsync(v => v.Id == id);
        }

        public  void AddVechile(Vechile vechile)
        {
            context.Vechiles.Add(vechile);
        }

        public void RemoveVechile(Vechile vechile)
        {
            context.Remove(vechile);
        }

        public async Task<IEnumerable<Vechile>> GetVechiles()
        {

           return await context.Vechiles
              .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
              .Include(v => v.Model)
                .ThenInclude(m => m.Make).
                ToListAsync();
        }
    }
}
