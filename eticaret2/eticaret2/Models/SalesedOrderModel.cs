using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Models
{
    public class SalesedOrderModel
    {
        [Key]
        public int sales_id { get; set; }
        public int product_id { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string traking_no { get; set; }
        public DateTime orderbydate { get; set; }
        public decimal price { get; set; }
        public int salesp_id { get; set; }



    }
}
