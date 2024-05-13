using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobFinder.API.DTO
{
    public class UsuarioDTO
    {
        public int? idCandidato { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int idCidade { get; set; }
        [Required]
        [PasswordPropertyText]
        public string password { get; set; }

    }
}
