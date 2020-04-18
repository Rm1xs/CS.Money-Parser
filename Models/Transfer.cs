using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudParser.Models
{
    public class Transfer
    {
        public string name { get; set; }
        public string custom_price { get; set; }
        public string floatvalue { get; set; }
        public DateTime update_time { get; set; }
        public int user_skin_id { get; set; }
    }
}
