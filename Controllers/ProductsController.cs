﻿using BigCorp.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BigCorpContext _context;

        public ProductsController(BigCorpContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = await _context.Products.Include(a => a.ProductLine).ToArrayAsync();
            return product;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.Include(a => a.ProductLine).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<Product>> PostProduct(int productLineId, string Storage)
        {
            var product = new Product();
            var productLine = await _context.ProductLines.FindAsync(productLineId);
            if (productLine == null)
                return BadRequest("ProductLine khong ton tai");
            product.ProductLine = productLine;
            product.Storage = Storage;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("ProductLineId/{ProductLineId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByProductLine(int ProductLineId)
        {
            var lst = await _context.Products.Include(p => p.ProductLine).Where(m => m.ProductLineId == ProductLineId).ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Status/{status}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByStatus(string status)
        {
            var lst = await _context.Products.Include(p => p.ProductLine).Where(m => m.Status == status).ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Storage/{storage}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByStorage(string storage)
        {
            var lst = await _context.Products.Include(p => p.ProductLine).Where(m => m.Storage == Storage).ToListAsync();
            return Ok(lst);
        }

        [HttpPut("ChangeStatus/{id}&{status}")]
        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            product.Status = status;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Chuyen trang thai thanh cong");
        }

        [HttpPut("MoveProduct/{id}&{adress}")]
        public async Task<IActionResult> MoveProduct(int id, string adress)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            product.Storage = adress;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Chuyen san pham thanh cong");
        }

        [HttpPut("Change/{id}&{status}&{adress}")]
        public async Task<IActionResult> Change(int id, string status, string adress)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            product.Status = status;
            product.Storage = adress;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Thay doi duoc chap nhan");
        }

        [HttpPut("Sell/{id}")]
        public async Task<IActionResult> Sell(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            if (product.Status == "Da ban")
                return BadRequest("San pham da ban");
            product.Status = "Da ban";
            product.Exp = DateTime.Now.AddMonths(24);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Giao dich thanh cong");
        }

        [HttpPut("Maintain/{id}")]
        public async Task<IActionResult> Maintain(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            if (product.Status == "Chua ban")
                return BadRequest("San pham chuan can bao duong");
            if (product.Exp < DateTime.Now)
            {
                await DeleteProduct(id);
                return BadRequest("San pham het han bao hanh");
            }
            product.Status = "Dang bao hanh";
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Da dem di bao duong");
        }

        [HttpPut("ReturnProduct/{id}")]
        public async Task<IActionResult> EeturnProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            if (product.Status != "Dang bao hanh")
                return BadRequest("San pham da duoc hoan tra");
            product.Status = "Da ban";
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Da tra lai san pham cho khach hang");
        }

        [HttpPut("Refund/{id}")]
        public async Task<IActionResult> Refund(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            if (product.Status != "Da ban")
                return BadRequest("San pham khong the hoan tra ngay");
            if (DateTime.Now > product.Exp.AddMonths(12))
                return BadRequest("San pham da qua han hoan tien");
            product.Status = "Chua ban";
            product.Exp = product.Mfg;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("San pham da duoc hoan tien");
        }

        [HttpDelete("Recycle/{id}")]
        public async Task<IActionResult> Recycle(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            if (product.Status != "Chua ban")
                return BadRequest("San pham khong the tai che");
            if (product.Exp < product.Mfg.AddMonths(48))
                return BadRequest("San pham chua can tai che");
            await DeleteProduct(id);
            return Ok("San pham da duoc hoan tien");
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
