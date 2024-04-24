using AutoMapper;
using JobFinder.API.DTO;
using JobFinder.API.Model;
using JobFinder.Data.DataBase;
using JobFinder.Data.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JobFinder.API.Service
{
    public class LoginService
    {
        private readonly IMapper _mapper;
        private readonly LoginDB _login;
        private readonly IConfiguration _configuration;

        public LoginService(IMapper mapper, LoginDB login, IConfiguration configuration)
        {
            _mapper = mapper;
            _login = login;
            _configuration = configuration;
        }
        public async Task<string> CreateLogin(LoginDTO loginDTO)
        {
            var login = _mapper.Map<LoginInsertModel>(loginDTO);
            byte[] hash;
            byte[] salt;
            try
            {

                using (var hmac = new HMACSHA512())
                {
                    hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.password));
                    salt = hmac.Key;
                }
                login.passorwdSalt = salt;
                login.passorwdHash = hash;
                if (await _login.CreateLogin(login)) 
                {
                    return await Authentication(loginDTO);
                }

            }
            catch (Exception ex) { }
            return null;
        }
        public async Task<string> Authentication(LoginDTO loginDTO)
        {
            try
            {
                var login = _mapper.Map<LoginModel>(loginDTO);
                var retLogin = await _login.BuscaLogin(login);
                if (await ValidaSenha(retLogin, loginDTO.password))
                {
                  return GenerateToken(retLogin);
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        private string GenerateToken(LoginModel login)
        {
            var claims = new[]
                   {
                        new Claim("id",login.id.ToString()),
                        new Claim("user", login.userLogin.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
            var privateKy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretkey"]));

            var crendentials = new SigningCredentials(privateKy, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: crendentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<bool> ValidaSenha(LoginModel login,string passowrd)
        {
            
            using var hmac = new HMACSHA512(login.PassorwdSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passowrd));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != login.PassowrdHash[i])
                {
                    return false;
                }
            }
            return true;
        }


    }
}
