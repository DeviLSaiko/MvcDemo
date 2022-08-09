using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.ComponentModel.DataAnnotations;

namespace Database1
{
    public class Db : IDb
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }

    public interface IDb
    {
        int ID { get; set; }
        [Required]
        string Password { get; set; }
      
    }
}
