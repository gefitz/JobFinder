using JobFinder.API.DTO;
using JobFinder.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : Controller
    {
        private readonly CidadeService _service;

        public CidadeController(CidadeService service)
        {
            _service = service;
        }
        [HttpGet("estado")]
        public Task<IEnumerable<CidadeDTO>> RecuperaEstado()
        {
            return _service.RecuperaEstado();
        }
        [HttpPost("cidade")]
        public Task<IEnumerable<CidadeDTO>> RecuperaCidade(string sigla)
        {
            return _service.RecuperaCidade(sigla);
        }
    }
}
