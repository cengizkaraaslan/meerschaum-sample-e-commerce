using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Entities
{
    public class Users : IEntity
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string company { get; set; }
        public string adress1 { get; set; }
        public string adress2 { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string regionstate { get; set; }
        public DateTime datetime { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}