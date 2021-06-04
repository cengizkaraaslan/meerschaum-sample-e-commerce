using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class Salesed : IEntity
    {
        [Key]
        public int sales_id { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string adress1 { get; set; }
        public string adress2 { get; set; }
        public string city { get; set; }
        public string telephone { get; set; }
        public int zip { get; set; }
        public decimal totalprice { get; set; }
        public decimal user_id { get; set; }
        public string traking_no { get; set; }
        public DateTime orderbydate { get; set; }


    }
    public class Salesed2 : IEntity
    {
        [Key]
        public int sales_id { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string adress1 { get; set; }
        public string adress2 { get; set; }
        public string city { get; set; }
        public string telephone { get; set; }
        public int zip { get; set; }
        public decimal totalprice { get; set; }
        public Products[] pro { get; set; }
        public decimal user_id { get; set; }


    }
}
