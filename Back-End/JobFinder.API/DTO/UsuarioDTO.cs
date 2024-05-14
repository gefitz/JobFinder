using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobFinder.API.DTO
{
    public class UsuarioDTO
    {
        public int? idUsuario{ get; set; }
        [Required]
        public string Nome_Usuario { get; set; }
        [Required]
        public string CPF_CNPJ { get; set; }
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
        public DateTime dthNascimento { get; set; }
        public DateTime dthRegistro { get; set; }
        public short tUsuario { get; set; }

    }
}
