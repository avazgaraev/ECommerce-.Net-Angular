using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution1.Application.Abstraction;
using System.Diagnostics.Contracts;

namespace Soltion1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }
    }
}
