﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
