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
using BigCorp.Repository.Interface;

namespace BigCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLinesController : ControllerBase
    {
        //private readonly BigCorpContext _context;
        private readonly IItemRepository<ProductLineModel, ProductLine> _productLineRepo;

        //public ProductLinesController(BigCorpContext context)
        //{
        //    _context = context;
        //}

        public ProductLinesController(IItemRepository<ProductLineModel, ProductLine> productLineRepo)
        {
            _productLineRepo = productLineRepo;
        }


        // GET: api/ProductLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLine>>> GetProductLines()
        {
            return await _productLineRepo.GetAllAsync();
        }

        // GET: api/ProductLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductLine>> GetProductLine(int id)
        {
            var productLine = await _productLineRepo.GetItemAsync(id);
            return productLine == null ? NotFound() : Ok(productLine);
        }

        // PUT: api/ProductLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductLine(int id, ProductLineModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            try
            {
                await _productLineRepo.UpdateItemAsync(id, model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductLineExists(id))
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

        // POST: api/ProductLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductLine>> PostProductLine(ProductLineModel model)
        {
            await _productLineRepo.AddItemAsync(model);
            return CreatedAtAction("GetProductLine", new { id = model.Id }, model);
        }

        // DELETE: api/ProductLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> removeStorageLine(int id)
        {
            try
            {
                await _productLineRepo.RemoveItemAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        private bool ProductLineExists(int id)
        {
            return _productLineRepo.ItemExists(id);
        }
    }
}
