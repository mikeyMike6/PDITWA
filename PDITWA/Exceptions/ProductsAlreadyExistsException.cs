using System;

namespace PDITWA.Exceptions
{
    public class ProductsAlreadyExistsException: Exception
    {
        public Guid Id { get; }
        public ProductsAlreadyExistsException(Guid id) : base($"Procuct with id {id} already exists.")
        {
            Id = id;
        }
    }
}
