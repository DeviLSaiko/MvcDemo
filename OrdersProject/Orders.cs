using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersProject
{
    public class Orders
    {
        [Key]
        public int OID { get; set; }
        public string OrderID { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string OrderType { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        [DataType(DataType.Date)]
[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ETA_Time { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime Created_Date { get; set; }
    }
}
