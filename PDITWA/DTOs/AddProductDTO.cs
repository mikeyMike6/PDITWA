using System;

namespace PDITWA.DTOs.Validators
{
    public class AddProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
