using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.Model
{
    public class UsuarioModel
    {
        public int? idUsuario { get; set; }
        public string Nome_Usuario { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int idCidade { get; set; }
        public int idLogin { get; set; }
        public DateTime dthNascimento { get; set; }
        public DateTime dthRegistro { get; set; }
        public short tUsuario { get; set; }
    }
    public class UsuarioInsertModel
    {
        public string Nome_Usuario { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int idCidade { get; set; }
        public int idLogin {  get; set; }
        public DateTime dthNascimento { get; set; }
        public DateTime dthRegistro { get; set; }
        public short tUsuario { get; set; }
    }

}
