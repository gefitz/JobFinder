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
    public class CidadeDB
    {
        private readonly Command _command;

        public CidadeDB(Command command)
        {
            _command = command;
        }
        public async Task<IEnumerable<CidadeModel>> RecuperaEstado()
        {
            string query = "Select Distinct Nome_Estado,Sigla_Estado from tbl_Cidade";
            List<CidadeModel> cidadeList = new List<CidadeModel>();
            try
            {
                SqlConnection conn = new SqlConnection();
                using (conn = _command.OpenConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = await cmd.ExecuteReaderAsync();
                        while (result.Read())
                        {
                            CidadeModel cidade = new CidadeModel();
                            cidade.Estado = result["Nome_Estado"].ToString();
                            cidade.SiglaEstado = result["Sigla_Estado"].ToString();
                            cidadeList.Add(cidade);
                        }
                    }
                    _command.CloseConnection(conn);
                }

            }
            catch (Exception ex) { }
            return cidadeList;

        }
        public async Task<IEnumerable<CidadeModel>> RecuperaCidade(string sigla)
        {
            string query = $"Select Distinct idCidade,Nome_Cidade from tbl_Cidade where Sigla_Estado = '{sigla}'";
            List<CidadeModel> cidadeList = new List<CidadeModel>();
            try
            {
                SqlConnection conn = new SqlConnection();
                using (conn = _command.OpenConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = await cmd.ExecuteReaderAsync();
                        while (result.Read())
                        {
                            CidadeModel cidade = new CidadeModel();
                            cidade.idCidade = Convert.ToInt32(result["idCidade"]);
                            cidade.Cidade = result["Nome_Cidade"].ToString();
                            cidadeList.Add(cidade);
                        }
                    }
                    _command.CloseConnection(conn);
                }

            }
            catch (Exception ex) { }
            return cidadeList;

        }
    }
}
