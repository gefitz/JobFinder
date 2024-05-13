using AutoMapper;
using JobFinder.API.DTO;
using JobFinder.API.Model;
using JobFinder.API.Service;
using JobFinder.Data.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JobFinder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost(Name = "CandidatoPost")]
        public async Task<ActionResult<UserToken>> CandidatoPostAsync(UsuarioDTO candidato)
        {
            if (candidato == null) { return BadRequest("Não foi passado as informações do Candidato"); }
            var token = await _service.CandidatoPostAsync(candidato);
            if (token.token != null)
            { return token; }
            return BadRequest("Falha ao tentar salvar o candidato");
        }
    }
}
