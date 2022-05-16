using Microsoft.AspNetCore.Mvc;
using PDITWA.Domain;
using PDITWA.DTOs;
using PDITWA.DTOs.Validators;
using PDITWA.Exceptions;
using System;

namespace PDITWA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("[action]")]
        public IActionResult Get(Guid id)
        {
            var product = _productsRepository.GetById(id);
            if (product is null)
                return NotFound();
            return Ok(new ProductDTO(product));
        }

        [HttpPost("[action]")]
        public IActionResult Add(AddProductDTO addProduct)
        {
            if(_productsRepository.Exists(addProduct.Id))
                throw new ProductsAlreadyExistsException(addProduct.Id);

            var product = new Product(addProduct.Id, addProduct.Name, addProduct.IsAvailable);
            _productsRepository.Add(product);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(UpdateProductDTO updateProduct)
        {
            if(!_productsRepository.Exists(updateProduct.Id))
                return NotFound();

            var product = new Product(updateProduct.Id, updateProduct.Name, updateProduct.IsAvailable);
            _productsRepository.Update(product);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(Guid id)
        {
            if(!_productsRepository.Exists(id))
                return NotFound();
            _productsRepository.Delete(id);
            return Ok();
        }

        [HttpPost("[action]")]
        public TestUserDTO Test(TestUserDTO user) => user;
    }
}
