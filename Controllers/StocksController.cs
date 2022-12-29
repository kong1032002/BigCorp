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
        private readonly IItemRepository<StockModel, Stock> _stockRepo;

        public StocksController(IItemRepository<StockModel, Stock> stockRepo)
        {
            _stockRepo = stockRepo;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            return await _stockRepo.GetAllAsync();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _stockRepo.GetItemAsync(id);
            return stock == null ? NotFound() : Ok(stock);
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, StockModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await _stockRepo.UpdateItemAsync(id, model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(StockModel model)
        {
            await _stockRepo.AddItemAsync(model);
            return CreatedAtAction("GetStock", new { id = model.Id }, model);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            try
            {
                await _stockRepo.RemoveItemAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool StockExists(int id)
        {
            return _stockRepo.ItemExists(id);
        }
    }
}
