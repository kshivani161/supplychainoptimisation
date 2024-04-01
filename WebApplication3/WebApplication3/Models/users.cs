using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        
        public string username { get; set; }
        public string password { get; set;}
    }
}
