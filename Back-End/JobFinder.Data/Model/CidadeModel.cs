using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.Model
{
    public class CidadeModel
    {
        public int idCidade { get; set; }
        public string Cidade { get; set; }
        public string SiglaEstado { get; set; }
        public string Estado { get; set; }
    }
}
