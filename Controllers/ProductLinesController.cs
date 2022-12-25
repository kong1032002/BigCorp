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
    public class ProductLinesController : ControllerBase
    {
        //private readonly BigCorpContext _context;
        private readonly IProductLineRepository _productLineRepo;

        //public ProductLinesController(BigCorpContext context)
        //{
        //    _context = context;
        //}

        public ProductLinesController(IProductLineRepository productLineRepo)
        {
            _productLineRepo = productLineRepo;
        }


        // GET: api/ProductLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLine>>> GetProductLines()
        {
            try
            {
                return Ok(await _productLineRepo.getProductLinesAsync());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return await _context.ProductLines.ToListAsync();
        }

        // GET: api/ProductLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductLine>> GetProductLine(int id)
        {
            var productLine = await _productLineRepo.getProductLineAsync(id);
            return productLine == null ? NotFound() : Ok(productLine);
            //var productLine = await _context.ProductLines.FindAsync(id);

            //if (productLine == null)
            //{
            //    return NotFound();
            //}

            //return productLine;
        }

        // PUT: api/ProductLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductLine(int id, ProductLineModel model)
        {
            await _productLineRepo.updateProductLineAsync(id, model);
            return Ok();
            //if (id != productLine.id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(productLine).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductLineExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/ProductLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductLine>> PostProductLine(ProductLineModel model)
        {
            try
            {
                var newProductLineId = await _productLineRepo.addProductLineAsync(model);
                var productLine = await _productLineRepo.getProductLineAsync(newProductLineId);
                return model == null ? NotFound() : Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //_context.ProductLines.Add(productLine);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProductLine", new { id = productLine.id }, productLine);
        }

        // DELETE: api/ProductLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductLine(int id)
        {
            //var productLine = await _context.ProductLines.FindAsync(id);
            //if (productLine == null)
            //{
            //    return NotFound();
            //}

            //_context.ProductLines.Remove(productLine);
            //await _context.SaveChangesAsync();

            //return NoContent();
            await _productLineRepo.deleteProductLineAsync(id);
            return Ok();
        }

        //private bool ProductLineExists(int id)
        //{
        //    return _context.ProductLines.Any(e => e.id == id);
        //}
    }
}
