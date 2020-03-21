﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Models
{
    public class Order : Entity
    {
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int Count { get; set; }
    }
}
