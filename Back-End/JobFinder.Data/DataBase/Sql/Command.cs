using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.DataBase.Sql
{
    public class Command
    {
        private readonly string _connectionString;

        public Command(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection OpenConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                return connection;
            }
            return connection;
        }
        public SqlConnection CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                return connection;
            }
            return connection;
        }
        public async Task<object> ExecuteProcedure(string nomeProcedure, object parametros)
        {
            SqlConnection connection = new SqlConnection();
            object ret = null;
            try
            {

                using (connection = OpenConnection(connection))
                {
                    using (SqlCommand command = new SqlCommand(nomeProcedure, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        foreach (var paremtro in parametros.GetType().GetProperties())
                        {
                            command.Parameters.AddWithValue("@" + paremtro.Name, paremtro.GetValue(parametros));
                        }
                        ret = await command.ExecuteReaderAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return ret;
            }
            return ret;
        }
        public async Task<bool> ExecuteInsert(string tabelaNome, object parametros)
        {
            SqlConnection connection = new SqlConnection();
            try
            {

                string cmdInsert = $"Insert {tabelaNome} (colunas) values (";
                SqlParameter[] sqlParameters = new SqlParameter[parametros.GetType().GetProperties().Length];
                int i = 0;
                string colunas = "";
                // Itera sobre as propriedades do objeto de parâmetros
                foreach (var propriedade in parametros.GetType().GetProperties())
                {
                    // Adiciona o nome da coluna à string de comando SQL
                    if (i == parametros.GetType().GetProperties().Length - 1)
                    {
                        cmdInsert += "@" + propriedade.Name;
                        colunas += propriedade.Name;
                    }
                    else
                    {
                        cmdInsert += "@" + propriedade.Name + ", ";
                        colunas += propriedade.Name + ",";
                    }

                    // Adiciona o parâmetro ao array de parâmetros
                    sqlParameters[i] = new SqlParameter("@" + propriedade.Name, propriedade.GetValue(parametros));
                    i++;
                }
                cmdInsert = cmdInsert.Replace("colunas", colunas);
                cmdInsert += ")";
                using (connection = OpenConnection(connection))
                {
                    using (SqlCommand command = new SqlCommand(cmdInsert, connection))
                    {
                        command.Parameters.AddRange(sqlParameters);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
