using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using vega.Persistence;
using AutoMapper;
using vega.Controllers.Resources;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly vegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(vegaDbContext context,IMapper mapper)
        {
            this.context = context; 
            this.mapper = mapper;

        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeResource>>(makes);

        }
        
    }
}