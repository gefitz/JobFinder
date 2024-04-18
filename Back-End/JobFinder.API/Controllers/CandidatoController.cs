using AutoMapper;
using JobFinder.API.DTO;
using JobFinder.API.Service;
using JobFinder.Data.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly CandidatoService _service;

        public CandidatoController(CandidatoService service)
        {
            _service = service;
        }

        [HttpPost(Name = "CandidatoPost")]
        public async Task<ActionResult> CandidatoPostAsync(CandidatoDTO candidato)
        {
            if (candidato == null) { return BadRequest("Não foi passado as informações do Candidato"); }
            if( await _service.CandidatoPostAsync(candidato)) { return Ok(); }
            return BadRequest("Falha ao tentar salvar o candidato");
        }
    }
}
