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
        public string userLogin { get; set; }
        public byte[] PassowrdHash { get; set; }
        public byte[] PassorwdSalt {  get; set; }
    }
    public class LoginInsertModel
    {
        public string userLogin { get; set; }
        public byte[] passorwdHash { get; set; }
        public byte[] passorwdSalt { get; set; }
    }
}
