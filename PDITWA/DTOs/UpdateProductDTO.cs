using System;
using System.ComponentModel.DataAnnotations;

namespace PDITWA.DTOs
{
    public class UpdateProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
