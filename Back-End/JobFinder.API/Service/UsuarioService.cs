using AutoMapper;
using JobFinder.API.DTO;
using JobFinder.API.Model;
using JobFinder.Data.DataBase;
using JobFinder.Data.Model;

namespace JobFinder.API.Service
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly CandidatoDB _dbCandidato;
        private readonly LoginService _loginService;

        public UsuarioService(IMapper mapper, CandidatoDB dbCandidato, LoginService loginService)
        {
            _mapper = mapper;
            _dbCandidato = dbCandidato;
            _loginService = loginService;

        }

        public async Task<UserToken> CandidatoPostAsync(UsuarioDTO candidatoDTO)
        {
            var candidato = _mapper.Map<UsuarioInsertModel>(candidatoDTO);
            UserToken token = await _loginService.CreateLogin(new LoginInsertModel { userLogin= candidatoDTO.Email }, candidatoDTO.password);
            if(token == null) { return null; }
            candidato.idLogin = token.idUsuario;
            if(await _dbCandidato.CandidatoPost(candidato))
            {
                return token;
            }
            return null;
        }
    }
}
