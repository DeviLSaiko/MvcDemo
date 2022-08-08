using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoMvc.Models
{
    [Table("Departments")]
    public class Departments
    {
        [Key]
        public int DepID { get; set; }
        public string DepName { get; set; }
         List<Users> Users { get; set; }
    }
}