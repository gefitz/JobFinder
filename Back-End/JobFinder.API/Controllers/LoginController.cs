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
        [HttpPost("authentication")]
        public async Task<ActionResult<UserToken>> Authentication(string username, string password)
        {
            if (username == null || password == null) { return BadRequest("Usuario/senha passados de forma vazia"); }
            var token = await _service.Authentication(username,password);
            if (token != null) {

                return token;
            }
            return BadRequest();
        }
    }
}
