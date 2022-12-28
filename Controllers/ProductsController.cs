using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;

namespace BigCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IItemRepository<ProductModel> _productRepo;

        public ProductsController(IItemRepository<ProductModel> productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                return Ok(await _productRepo.GetAllAsync());
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
            var product = await _productRepo.GetItemAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductModel model)
        {
            await _productRepo.UpdateItemAsync(id, model);
            return Ok();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProduct(ProductModel model)
        {
            try
            {
                var newProductId = await _productRepo.AddItemAsync(model);
                var product = await _productRepo.GetItemAsync(newProductId);
                return product == null ? NotFound() : Ok(model);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> removeStorage(int id)
        {
            await _productRepo.RemoveItemAsync(id);
            return Ok();
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.id == id);
        //}
    }
}
