using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly BigCorpContext _context;
        public ProductRepository(BigCorpContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductModel>> getProductsAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> getProductAsync(int id)
        {
            var product = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }
        public async Task<int> addProductAsync(ProductModel model)
        {
            var newProduct = _mapper.Map<Product>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.id;
        }

        public async Task deleteProductAsync(int id)
        {
            var deleteProduct = _context.Products!.SingleOrDefault(b=> b.id == id);
            if(deleteProduct != null)
            {
                _context.Products!.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task updateProductAsync(int id, ProductModel model)
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
