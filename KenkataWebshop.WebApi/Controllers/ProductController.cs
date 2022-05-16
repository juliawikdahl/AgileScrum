using KenkataWebshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Solution1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = new List<ProductDto>
            {
                new ProductDto
                {
                    Name = "Träolja",
                 
                },
                new ProductDto
                {
                    Name = "Boll",
                   
                }
            };

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = new ProductDto
            {
                Name = "Träolja",
              
            };

            return Ok(product);
        }
    }
}
