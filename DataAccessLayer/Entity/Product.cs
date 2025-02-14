using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Type{ get; set; }
        public string  Place{ get; set; }
        public int  Price{ get; set; }

    }
}
