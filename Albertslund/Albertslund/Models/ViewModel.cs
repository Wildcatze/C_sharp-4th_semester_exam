using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Models
{
    public class ViewModel
    {
        public User user { get; set; }
        public UserAddress userAddress { get; set; }
        public UserContact userContact { get; set; }
        public UserHouse userHouse { get; set; }
        public Email email { get; set; }
    }
}
