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
        public async Task<UserToken> CreateLogin(LoginInsertModel login,string password)
        {
            byte[] hash;
            byte[] salt;
            try
            {

                using (var hmac = new HMACSHA512())
                {
                    hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    salt = hmac.Key;
                }
                login.salt = salt;
                login.hash = hash;
                if (await _login.CreateLogin(login))
                {

                    return await Authentication(login.usuario, password) ;
                }

            }
            catch (Exception ex) { }
            return null;
        }

        public async Task<UserToken> Authentication(string username, string password)
        {
            try
            {
                var retLogin = await _login.BuscaLogin(username);
                if (await ValidaSenha(retLogin, password))
                {
                  return GenerateToken(retLogin);
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        private UserToken GenerateToken(LoginModel login)
        {
            var claims = new[]
                   {
                        new Claim("id",login.id.ToString()),
                        new Claim("user", login.usuario.ToString()),
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
            return new UserToken() {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                idUsuario = Convert.ToInt32(login.id)
            };
        }
        private async Task<bool> ValidaSenha(LoginModel login,string passowrd)
        {
            
            using var hmac = new HMACSHA512(login.salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passowrd));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != login.hash[i])
                {
                    return false;
                }
            }
            return true;
        }


    }
}
