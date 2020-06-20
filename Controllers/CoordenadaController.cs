using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCovid.Data;
using GeoCovid.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GeoCovid.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CoordenadaController : ControllerBase
    {
           public CoordenadaController(DataContext context) 
        {
            this.Context = context;
               
        }
        public DataContext Context { get; }

        [HttpGet]
        public  async Task<ActionResult<List<Coordenada>>> Get()
        {
            var RCoordenadas = await Context.Coordenadas.ToListAsync();
            return RCoordenadas;
        }
  
        [HttpPost]
        [Route("especifico")]
        [Authorize]
        public  async Task<ActionResult<Coordenada>> GetEspecifico(
             [FromBody]Coordenada model)
        {
            var RCoordenadas = Context.Coordenadas.FirstOrDefault(x => x.Email == model.Email);

            return RCoordenadas;
        }

        [HttpPost]
        [Authorize]
        public  async Task<ActionResult<Coordenada>> Post(
       
            [FromBody]Coordenada model)
            {
            if (ModelState.IsValid)
            {
                try
                {
                    Context.Coordenadas.Add(model);
                    await Context.SaveChangesAsync();
                    return model;
                }
                catch (System.Exception)
                {
                    
                    Context.Update(model);
                    await Context.SaveChangesAsync();
                    return model;
                }
  
            }else
            {
                return BadRequest(ModelState.IsValid);
            }
        }

        [HttpPut]
        [Authorize]
        public  async Task<ActionResult<Coordenada>> Put(
       
            [FromBody]Coordenada model)
            {
            if (ModelState.IsValid)
            {
            Context.Update(model);
            await Context.SaveChangesAsync();
            return model;
            }else
            {
                return BadRequest(ModelState.IsValid);
            }
        }

        [HttpPost]
        [Route("remover")]
        [Authorize]
        public  async Task<ActionResult<Coordenada>> HttpDelete(
       
            [FromBody]Coordenada model)
            {//return NotFound(new { message = User.Identity.Name });
           
         if (ModelState.IsValid)
           {
                if (model.Email != User.Identity.Name)
             {
                return NotFound(new { message = "Token Invalido Para esta ação" });
           }

            Context.Remove(Context.Coordenadas.FirstOrDefault(x => x.Email == model.Email));
            await Context.SaveChangesAsync();
            return model;
            }else
            {
                return BadRequest(ModelState.IsValid);
            }
        }

    }
}