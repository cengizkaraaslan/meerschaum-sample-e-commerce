using eticaret.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class UnderCategory : IEntity
    {
        [Key]
        public int under_category_id { get; set; }
        public string category_name { get; set; }
        public int category_id { get; set; }
    }
}
