﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public interface IEntranceRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
