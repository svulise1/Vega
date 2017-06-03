using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Persistence;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Controllers
{
    public class FeatureController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeatureController(VegaDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

       [HttpGet("api/features")]
        public async Task<IEnumerable<FeatureResource>> GetMakes()
        {
            
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);

        }
    }
}
