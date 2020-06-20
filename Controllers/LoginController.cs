using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using GeoCovid.Data;
using GeoCovid.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace GeoCovid.Services
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        public LoginController(DataContext context) 
        {
            this.Context = context;
               
        }
        public DataContext Context { get; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody]Usuario model)
        {
             Usuario user;
            try
            {
               user = Context.Usuario.FirstOrDefault(x => x.EmailTelefone == model.EmailTelefone && x.Senha == model.Senha);
            }
            catch (System.Exception)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
            

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            var RCoordenadas = Context.Coordenadas.FirstOrDefault(x => x.Email == model.EmailTelefone);
            return new
            {
                user = user,
                coordenada = RCoordenadas,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    }
}