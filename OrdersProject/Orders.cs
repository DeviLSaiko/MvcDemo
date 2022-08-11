using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Orderid ")]
        public string OrderID { get; set; }

        [Required]
        [DisplayName("Customer name")]
        public string ClientName { get; set; }

        [Required]
        [DisplayName("Product")]
        public string OrderType { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Qty { get; set; }

        [Required]
        [DisplayName("DeadLine")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ETA_Time { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime Created_Date { get; set; }
    }
}
