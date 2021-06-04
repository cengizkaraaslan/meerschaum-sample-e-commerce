using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class Category:IEntity
    {
        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int mothercategory_id { get; set; }
    }
}
