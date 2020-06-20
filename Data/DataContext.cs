using GeoCovid.Model;
using Microsoft.EntityFrameworkCore;

namespace GeoCovid.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<Evento> Eventos {get; set; }
        public DbSet<Coordenada> Coordenadas {get; set; }
         public DbSet<Usuario> Usuario {get; set; }
    }
}