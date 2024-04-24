using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.API.DTO
{
    public class LoginDTO
    {
        public int? id {  get; set; }
        public string userLogin { get; set; }
        [PasswordPropertyText]
        [NotMapped]
        public string password { get; set; }
    }
}
