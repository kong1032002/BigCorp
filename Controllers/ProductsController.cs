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
        private readonly IItemRepository<ProductModel, Product> _productRepo;

        public ProductsController(IItemRepository<ProductModel, Product> productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productRepo.GetAllAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _productRepo.GetItemAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await _productRepo.UpdateItemAsync(id, model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProduct(ProductModel model)
        {
            await _productRepo.AddItemAsync(model);
            return CreatedAtAction("GetProduct", new { id = model.Id }, model);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> removeStorage(int id)
        {
            try
            {
                await _productRepo.RemoveItemAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _productRepo.ItemExists(id);
        }
    }
}
