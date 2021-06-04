using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Models
{
    public class ProductModel
    {
        [Key]
        public int Product_ID { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        public int Category_ID { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int? Satus_ID { get; set; }
        public int Raiting { get; set; }
        public string Category_Name { get; set; }
 
    }
}
