﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }    
        public string Region { get; set; }

    }
}
