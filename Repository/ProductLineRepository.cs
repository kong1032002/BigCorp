using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class ProductLineRepository : IItemRepository<ProductLineModel>
    {
        private readonly BigCorpContext _context;
        private readonly IMapper _mapper;

        public ProductLineRepository(BigCorpContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddItemAsync(ProductLineModel model)
        {
            var newProductLine = _mapper.Map<ProductLine>(model);
            _context.ProductLines.Add(newProductLine);
            await _context.SaveChangesAsync();
            return newProductLine.id;
        }

        public async Task RemoveItemAsync(int id)
        {
            var removeStorageLine = _context.ProductLines!.SingleOrDefault(b => b.id == id);
            if (removeStorageLine != null)
            {
                _context.ProductLines.Remove(removeStorageLine);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ProductLineModel> GetItemAsync(int id)
        {
            var productLine = await _context.ProductLines!.FindAsync(id);
            return _mapper.Map<ProductLineModel>(productLine);
        }

        public async Task<List<ProductLineModel>> GetAllAsync()
        {
            var productLines = await _context.ProductLines!.ToListAsync();
            return _mapper.Map<List<ProductLineModel>>(productLines);
        }

        public async Task UpdateItemAsync(int id, ProductLineModel model)
        {
            if (id == model.id)
            {
                var updateProductLine = _mapper.Map<ProductLine>(model);
                _context.ProductLines!.Update(updateProductLine);
                await _context.SaveChangesAsync();
            }
        }
    }
}
