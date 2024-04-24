using JobFinder.API.DTO;
using JobFinder.API.Model;
using JobFinder.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly LoginService _service;
        public LoginController(LoginService service)
        {
            _service = service;
        }
        [HttpPost("create")]
        public async Task<ActionResult<UserToken>> CreateLogin(LoginDTO login) 
        {
            if(login == null) { return BadRequest("Favor colocar as informações de login"); }
            var token = await _service.CreateLogin(login);
            if (token != null)
            {
                return new UserToken
                {
                    token = token,
                };
            }
            return BadRequest("Não foi possivel realizar o cadastro de login");
        }
        [HttpPost("authentication")]
        public async Task<ActionResult<UserToken>> Authentication(LoginDTO login)
        {
            if (login == null) { return BadRequest("Usuario/senha incorretas"); }
            var token = await _service.Authentication(login);
            if (token != null) {

                return new UserToken
                {
                    token = token,
                };
            }
            return BadRequest();
        }
    }
}
