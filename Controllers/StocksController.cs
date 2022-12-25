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
    public class StocksController : ControllerBase
    {
        private readonly IItemRepository<StockModel> _stockRepo;

        public StocksController(IItemRepository<StockModel> stockRepo)
        {
            _stockRepo = stockRepo;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            try
            {
                return Ok(await _stockRepo.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _stockRepo.GetItemAsync(id);
            return stock == null ? NotFound() : Ok(stock);
            //var stock = await _context.Stocks.FindAsync(id);

            //if (stock == null)
            //{
            //    return NotFound();
            //}

            //return stock;
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, StockModel model)
        {
            await _stockRepo.UpdateItemAsync(id, model);
            return Ok();
            //if (id != stock.id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(stock).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StockExists(id))
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

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(StockModel model)
        {
            try
            {
                var newStockId = await _stockRepo.AddItemAsync(model);
                var product = await _stockRepo.GetItemAsync(newStockId);
                return model == null ? NotFound() : Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //_context.Stocks.Add(stock);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStock", new { id = stock.id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await _stockRepo.RemoveItemAsync(id);
            return Ok();
            //var stock = await _context.Stocks.FindAsync(id);
            //if (stock == null)
            //{
            //    return NotFound();
            //}

            //_context.Stocks.Remove(stock);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        //private bool StockExists(int id)
        //{
        //    return _context.Stocks.Any(e => e.id == id);
        //}
    }
}
