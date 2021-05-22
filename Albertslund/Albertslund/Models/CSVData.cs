using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Models
{
    public class CSVData
    {
        public int reading_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string energy { get; set; }
        public string water { get; set; }
        public int user_id { get; set; }

    }
}
