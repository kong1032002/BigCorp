using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigCorp.Datas;
using BigCorp.Repository;
using BigCorp.Models;

namespace BigCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                return Ok(await _productRepo.getProductsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.getProductAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductModel model)
        {
            await _productRepo.updateProductAsync(id, model);
            return Ok();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProduct(ProductModel model)
        {
            try
            {
                var newProductId = await _productRepo.addProductAsync(model);
                var product = await _productRepo.getProductAsync(newProductId);
                return model == null ? NotFound() : Ok(model);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepo.deleteProductAsync(id);
            return Ok();
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.id == id);
        //}
    }
}
