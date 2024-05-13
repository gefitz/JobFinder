using JobFinder.Data.DataBase.Sql;
using JobFinder.Data.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.DataBase
{
    public class LoginDB
    {
        private readonly Command _command;

        public LoginDB(Command command)
        {
            _command = command;
        }
        public async Task<LoginModel> BuscaLogin(string username)
        {
            var query = $"Select idLogin,userLogin,passwordSalt,passwordHash from tbl_Login where userLogin='{username}'";
            SqlConnection connection = new SqlConnection();
            LoginModel login = new LoginModel();
            try
            {
                using (connection = _command.OpenConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        var result = await cmd.ExecuteReaderAsync();
                        while(result.Read())
                        {
                            login.id = Convert.ToInt32(result["idLogin"].ToString());
                            login.userLogin = Convert.ToString(result["userLogin"]);
                            login.passwordSalt = (byte[])result["passwordSalt"];
                            login.passwordHash = (byte[])result["passwordHash"];
                        }
                    }
                    _command.CloseConnection(connection);
                }
                return login;
            }
            catch (Exception ex) { }
            return login;
        }
        public async Task<bool> CreateLogin(LoginInsertModel login)
        {
            if (login != null)
            {
                try
                {
                    if (await _command.ExecuteInsert("tbl_Login", login)) { return true; };
                }
                catch (Exception ex) { return false; }
            }
            return false;
        }
        public async Task<bool> AlterarSenha(UsuarioModel login)
        {
            return false;
        }
    }
}
