using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionCart.Models
{
    public class Product
    {

        public Product()
        {
            Name = string.Empty;
            ThumbnailPath = string.Empty;
            ThumbnailAltText = string.Empty;
            ItemNumber = string.Empty;
            PartNumber = string.Empty;
            Price = 0.0;
            Weight = 0;
        }
        
        public string Name { get; set; }
        public string ItemNumber { get; set; }
        public string PartNumber { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ThumbnailPath { get; set; }
        public string ThumbnailAltText { get; set; }
        public string ModelGuid { get; set; }
        public string Category { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}
