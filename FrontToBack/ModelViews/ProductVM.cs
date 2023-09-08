﻿using FrontToBack.Entities;

namespace FrontToBack.ModelViews
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        //public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
