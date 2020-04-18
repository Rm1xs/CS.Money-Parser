using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudParser.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int CustomeId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Quality { get; set; }

    }
}
