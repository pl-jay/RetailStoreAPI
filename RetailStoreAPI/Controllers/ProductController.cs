using Microsoft.AspNetCore.Mvc;
using DAL;
using RetailStoreAPI.Entities.Models;
using RetailStoreAPI.Entities.ViewModels;
using RetailStoreAPI.DAL;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace RetailStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBll productBll;

        public ProductController(IProductBll productBll)
        {
            this.productBll = productBll;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await productBll.GetProducts());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var Product = await productBll.GetProductById(id);
            if(Product != null) return Ok(Product);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(AddProductRequest addProduct)
        {
            return Ok(await productBll.SaveProduct(addProduct));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProduct updateProduct)
        {
            var product = await productBll.UpdateProduct(id, updateProduct);
            if(product != null) return Ok();
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var Product = await productBll.DeleteProduct(id);
            if(Product != null) return Ok();
            return NotFound();
        }
    }
}
