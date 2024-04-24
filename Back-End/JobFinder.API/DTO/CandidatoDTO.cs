namespace JobFinder.API.DTO
{
    public class CandidatoDTO
    {
        public int? idCandidato { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int idCidade { get; set; }
        public LoginDTO Login { get; set; }

    }
}
