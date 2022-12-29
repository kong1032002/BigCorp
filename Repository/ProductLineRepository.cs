using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class ProductLineRepository : IItemRepository<ProductLineModel,ProductLine>
    {
        private readonly BigCorpContext _context;
        private readonly IMapper _mapper;

        public ProductLineRepository(BigCorpContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddItemAsync(ProductLineModel model)
        {
            var newProductLine = _mapper.Map<ProductLine>(model);
            _context.ProductLines.Add(newProductLine);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int Id)
        {
            var productLine = await GetItemAsync(Id);
            _context.ProductLines.Remove(productLine);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductLine> GetItemAsync(int Id)
        {
            return await _context.ProductLines.FindAsync(Id);
        }

        public async Task<List<ProductLine>> GetAllAsync()
        {
            return await _context.ProductLines.ToListAsync();
        }

        public async Task UpdateItemAsync(int Id, ProductLineModel model)
        {
            if (Id == model.Id)
            {
                var productLine = _mapper.Map<ProductLine>(model);
                _context.Entry(productLine).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        public bool ItemExists(int id)
        {
            return _context.ProductLines.Any(e => e.Id == id);
        }
    }
}
