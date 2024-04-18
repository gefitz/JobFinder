using AutoMapper;
using JobFinder.API.DTO;
using JobFinder.Data.DataBase;
using JobFinder.Data.Model;

namespace JobFinder.API.Service
{
    public class CandidatoService
    {
        private readonly IMapper _mapper;
        private readonly CandidatoDB _dbCandidato;

        public CandidatoService(IMapper mapper, CandidatoDB dbCandidato)
        {
            _mapper = mapper;
            _dbCandidato = dbCandidato;
        }

        public async Task<bool> CandidatoPostAsync(CandidatoDTO candidatoDTO)
        {
            var candidato = _mapper.Map<CandidatoInsertModel>(candidatoDTO);
            if(await _dbCandidato.CandidatoPost(candidato))
            {
                return true;
            }
            return false;
        }
    }
}
