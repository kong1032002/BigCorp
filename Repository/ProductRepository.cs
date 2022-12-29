using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class ProductRepository : IItemRepository<ProductModel, Product>
    {
        private readonly IMapper _mapper;
        private readonly BigCorpContext _context;
        public ProductRepository(BigCorpContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetItemAsync(int Id)
        {
            return await _context.Products.FindAsync(Id);
        }
        public async Task AddItemAsync(ProductModel model)
        {
            var product = _mapper.Map<Product>(model);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int Id)
        {
            var product = await GetItemAsync(Id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int Id, ProductModel model)
        {
            var product = _mapper.Map<Product>(model);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public bool ItemExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
