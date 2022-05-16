using PDITWA.Domain;
using System;

namespace PDITWA.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public ProductDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            IsAvailable = product.IsAvailable; 
        }
    }
}
