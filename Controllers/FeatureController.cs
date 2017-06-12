using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Persistence;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Controllers
{
    public class FeatureController : Controller
    {
        private readonly vegaDbContext context;
        private readonly IMapper mapper;
        public FeatureController(vegaDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

       [HttpGet("api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetMakes()
        {
            
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);

        }
    }
}
