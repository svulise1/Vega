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
    [Route("/api/vechiles")]
    public class VechileController : Controller
    {
        protected readonly IMapper mapper;
        protected readonly VegaDbContext context;
        public VechileController(IMapper mapper, VegaDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVechile([FromBody] VechileResource vechileresource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var vechile = mapper.Map<VechileResource, Vechile>(vechileresource);
            vechile.LastUpdate = DateTime.Now;
            context.Vechiles.Add(vechile);
            await context.SaveChangesAsync();
            var result = mapper.Map<Vechile, VechileResource>(vechile);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVechile(int id,[FromBody] VechileResource vechileresource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var vechile = await context.Vechiles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vechile == null)
                return NotFound();
            mapper.Map<VechileResource, Vechile>(vechileresource,vechile); 
            vechile.LastUpdate = DateTime.Now;
           
            await context.SaveChangesAsync();
            var result = mapper.Map<Vechile, VechileResource>(vechile);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVechile(int id)
        {
            var vechile =  await context.Vechiles.FindAsync(id);
            if (vechile == null)
                return NotFound();
            context.Remove(vechile);
             await context.SaveChangesAsync();
            return Ok(id);
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetVechile(int id)
        {
            var vechile = await context.Vechiles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vechile == null)
                return NotFound();
            var vechileresoruce = mapper.Map<Vechile, VechileResource>(vechile);
            return Ok(vechileresoruce);


        }
    }
}
