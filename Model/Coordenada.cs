using System.ComponentModel.DataAnnotations;

namespace GeoCovid.Model
{
    public class Coordenada
    {
        [Key]
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }
    }
}