using AutoMapper;
using JobFinder.API.DTO;
using JobFinder.Data.DataBase;

namespace JobFinder.API.Service
{
    public class CidadeService
    {
        private readonly CidadeDB _cidadeDB;
        private readonly IMapper _map;

        public CidadeService(CidadeDB cidadeDB,IMapper map)
        {
            _cidadeDB = cidadeDB;
            _map = map;
        }
        public async Task<IEnumerable<CidadeDTO>> RecuperaEstado()
        {
            return _map.Map<IEnumerable<CidadeDTO>>(await _cidadeDB.RecuperaEstado());
        }
        public async Task<IEnumerable<CidadeDTO>> RecuperaCidade(string sigla)
        {
            return _map.Map<IEnumerable<CidadeDTO>>(await _cidadeDB.RecuperaCidade(sigla));
        }
    }
}
