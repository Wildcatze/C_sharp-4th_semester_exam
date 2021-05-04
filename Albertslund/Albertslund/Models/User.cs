using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int reading_id { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public int bank_id { get; set; }
        public int house_id { get; set; }
    }
}
