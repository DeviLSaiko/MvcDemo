using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoMvc.Models
{
    [Table("Userinfo")]
    public class Users
    {
       [Key] public int UID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
         
    }
}