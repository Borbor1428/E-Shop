﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyLayer.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
