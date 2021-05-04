using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Models
{
    public class UserAddress
    {
        public int address_id { get; set; }
        public string street_name { get; set; }
        public int street_no { get; set; }
        public int ZIP { get; set; }
        public string region { get; set; }

    }
}
