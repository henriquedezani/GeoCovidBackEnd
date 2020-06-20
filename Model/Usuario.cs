using System.ComponentModel.DataAnnotations;

namespace GeoCovid.Model
{
    public class Usuario
    {   
        [Key]
        public string EmailTelefone { get; set; }
        public string Senha { get; set; }
        
    }
}