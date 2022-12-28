using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigCorp.Datas;
using BigCorp.Repository.Interface;
using BigCorp.Models;

namespace BigCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IItemRepository<StorageModel> _repo;
        private readonly BigCorpContext _context;

        public StoragesController(IItemRepository<StorageModel> repo)
        {
            _repo = repo;
        }

        // GET: api/Storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> GetStorages()
        {
            //return await _context.Storages.ToListAsync();
            try
            {
                return Ok(await _repo.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetStorage(int id)
        {
            var storage = await _repo.GetItemAsync(id);
            return storage == null ? NotFound() : Ok(storage);
        }

        // PUT: api/Storages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage(int id, StorageModel model)
        {
            await _repo.UpdateItemAsync(id, model);
            return Ok();
            //if (id != storage.id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(storage).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StorageExists(id))
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

        // POST: api/Storages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Storage>> PostStorage(StorageModel model)
        {
            try
            {
                var newStorageId = await _repo.AddItemAsync(model);
                var storage = await _repo.GetItemAsync(newStorageId);
                return storage == null ? NotFound() : Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //_context.Storages.Add(storage);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStorage", new { id = storage.id }, storage);
        }

        // DELETE: api/Storages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage(int id)
        {
            var storage = await _context.Storages.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }

            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageExists(int id)
        {
            return _context.Storages.Any(e => e.id == id);
        }
    }
}
