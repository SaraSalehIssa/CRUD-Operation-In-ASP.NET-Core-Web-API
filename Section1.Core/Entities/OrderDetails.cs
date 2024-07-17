﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }

    }
}
