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

namespace GeoCovid.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
           public UsuarioController(DataContext context) 
        {
            this.Context = context;
               
        }
        public DataContext Context { get; }

        [HttpGet]
        public  async Task<ActionResult<List<Usuario>>> Get()
        {
            var Users = await Context.Usuario.ToListAsync();
            return Users;
        }
  
        [HttpPost]
        public  async Task<ActionResult<Usuario>> Post(
       
            [FromBody]Usuario model)
 {
            if (ModelState.IsValid)
            {
            Context.Usuario.Add(model);
            await Context.SaveChangesAsync();
            return model;
            }else
            {
                return BadRequest(ModelState.IsValid);
            }
        }


    }
}