using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.Model
{
    public class LoginModel
    {
        public int? id { get; set; }
        public string usuario { get; set; }
        public byte[] hash { get; set; }
        public byte[] salt { get; set; }
    }
    public class LoginInsertModel
    {
        public string usuario { get; set; }
        public byte[] hash { get; set; }
        public byte[] salt { get; set; }
    }
}
