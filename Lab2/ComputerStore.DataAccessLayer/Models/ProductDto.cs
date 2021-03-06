﻿namespace ComputerStore.DataAccessLayer.Models
{
    public class ProductDto : IEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AmountInStorage { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set; }
    }
}