﻿namespace DataAccesLayer.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CountInStorage { get; set; }
        public int ManufacturerId { get; set; }
        public int SupplyId { get; set; }
        public int CategoryId { get; set; }
    }
}