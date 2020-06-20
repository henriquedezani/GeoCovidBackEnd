using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCovid.Data;
using GeoCovid.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace GeoCovid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(DataContext context) 
        {
            this.Context = context;
               
        }
                public DataContext Context { get; }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
       // {
         //   _logger = logger;
       // }

       [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {   
            return Context.Eventos.FirstOrDefault(x => x.EventoId == id );
        }

        [HttpGet]
        public IActionResult Get()
        {
                //return Context.Eventos.ToList();
            try
            {
               
                return Ok(Context.Eventos.ToList());
            }
            catch (System.Exception)
            {
                
                 return this.StatusCode(500 , "Erro de bando de dados");
            }
            


          //  return new Evento[] {
            //    new Evento() {
              //  EventoId = 1,
              //  Tema = "Meu teste",
               // Local ="sao paulo",
                //Lote = "1º",
               // QtdPessoas = 250,
               // DataEvento = "29/06/1991"
            //}
            //};
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //    Date = DateTime.Now.AddDays(index),
            //     TemperatureC = rng.Next(-20, 55),
            //      Summary = Summaries[rng.Next(Summaries.Length)]
            //  })
            //  .ToArray();
        }
    }
}
