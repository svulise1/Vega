﻿using AutoMapper;
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
using Vega.Core;

namespace Vega.Controllers
{
    [Route("/api/vechiles")]
    public class VechileController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        private readonly IVechileRepo repository;
        private readonly IUnitOfWork unitofwork;
        public VechileController(IMapper mapper, VegaDbContext context,IVechileRepo repository,IUnitOfWork unitofwork)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
            this.unitofwork = unitofwork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVechile([FromBody] SaveVechileResource vechileresource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var vechile = mapper.Map<SaveVechileResource, Vechile>(vechileresource);
            vechile.LastUpdate = DateTime.Now;
            repository.AddVechile(vechile);
            vechile = await repository.GetVechile(vechile.Id);
            await unitofwork.Complete();
            await repository.GetVechile(vechile.Id);
            var result = mapper.Map<Vechile, VechileResource>(vechile);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVechile(int id,[FromBody] SaveVechileResource vechileresource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var vechile = await repository.GetVechile(id);
            if (vechile == null)
                return NotFound();
            mapper.Map<SaveVechileResource, Vechile>(vechileresource,vechile); 
            vechile.LastUpdate = DateTime.Now;

            await unitofwork.Complete();
            var result = mapper.Map<Vechile, VechileResource>(vechile);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVechile(int id)
        {
            var vechile = await repository.GetVechile(id, Includerelated: false);
            if (vechile == null)
                return NotFound();
            repository.RemoveVechile(vechile);
            await unitofwork.Complete();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public  async Task<IActionResult> GetVechile(int id)
        {
            var vechile = await repository.GetVechile(id);
            if (vechile == null)
                return NotFound();
            var vechileresoruce = mapper.Map<Vechile, VechileResource>(vechile);
            return Ok(vechileresoruce);


        }
    }
}
