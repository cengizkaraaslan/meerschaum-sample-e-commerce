using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class Products : IEntity
    {
        [Key]
        public int Product_ID { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Info { get; set; }
        public int mothercategory_id { get; set; }
        public int Category_ID { get; set; }
        public int undercategory_id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int? Satus_ID { get; set; }
        public decimal discount { get; set; }
        public int raiting { get; set; }
        public decimal shipping { get; set; }

    }
}
