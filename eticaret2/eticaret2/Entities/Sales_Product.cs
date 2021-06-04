using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class Sales_Product : IEntity
    {
        [Key]
        public int salesp_id { get; set; }
        public int salesed_id { get; set; }
        public int product_id { get; set; }

    }
}
