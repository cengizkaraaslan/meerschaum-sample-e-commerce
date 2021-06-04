using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class MotherCategory : IEntity
    {
        [Key]
        public int mothercategory_id { get; set; }
        public string category_name { get; set; }
    }
}
