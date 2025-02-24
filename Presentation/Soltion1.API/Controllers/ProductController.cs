using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution1.Application.Repositories.ProductRepository;
using Solution1.Application.ViewModels.Products;
using Solution1.Domain.Entities.Common;
using System.Diagnostics.Contracts;

namespace Soltion1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteService;
        private readonly IProductReadRepository _productReadService;
        public ProductController(IProductWriteRepository productWriteService, IProductReadRepository productReadService)
        {
            _productWriteService = productWriteService;
            _productReadService = productReadService;
        }

        [HttpGet]
        public async Task<IQueryable<Product>> Get()
        {
            IQueryable<Product> products= _productReadService.GetAll(false);
            return products;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(string id)
        {
            Product product = await _productReadService.GetByIdAsync(id,false);
            return product;

        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Product_Create model)
        {
            if (!ModelState.IsValid)
            {
            }

            await _productWriteService.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });
            await _productWriteService.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Product_Update model)
        {
            Product product = await _productReadService.GetByIdAsync(model.ID);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteService.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteService.RemoveAsync(id);
            await _productWriteService.SaveAsync();
            return Ok();
        }
    }
}
