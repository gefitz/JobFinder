using JobFinder.Data.DataBase.Sql;
using JobFinder.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.DataBase
{
    public class CandidatoDB
    {
        private readonly Command _command;

        public CandidatoDB(Command command)
        {
            _command = command;
        }
        public async Task<bool> CandidatoPost(UsuarioInsertModel candidato)
        {
            if (candidato == null) return false;

            if (await _command.ExecuteInsert("tbl_Candidato", candidato))
            {

                return true;
            };

            return false;
        }
    }
}
