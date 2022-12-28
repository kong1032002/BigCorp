using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class ProductRepository : IItemRepository<ProductModel>
    {
        private readonly IMapper _mapper;
        private readonly BigCorpContext _context;
        public ProductRepository(BigCorpContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductModel>> GetAllAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> GetItemAsync(int id)
        {
            var product = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }
        public async Task<int> AddItemAsync(ProductModel model)
        {
            var newProduct = _mapper.Map<Product>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.id;
        }

        public async Task RemoveItemAsync(int id)
        {
            var removeStorage = _context.Products!.SingleOrDefault(b=> b.id == id);
            if(removeStorage != null)
            {
                _context.Products!.Remove(removeStorage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateItemAsync(int id, ProductModel model)
        {
            if(id == model.id)
            {
                var updateProduct = _mapper.Map<Product>(model);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }

    }
}
