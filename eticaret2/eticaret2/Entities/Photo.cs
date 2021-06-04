using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class Photo : IEntity
    {
        [Key]
        public int Photo_ID { get; set; }
        public string Url { get; set; }
        public int Product_ID { get; set; }
    }
}
