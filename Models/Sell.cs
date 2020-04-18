using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudParser.Models
{
    public class Sell
    {
        public string name { get; set; }
        public List<Sale> sales { get; set; }
    }
    public class Sale
    {
        public string custom_price { get; set; }
        public string floatvalue { get; set; }
        public int update_time { get; set; }
        public int user_skin_id { get; set; }
    }
}
