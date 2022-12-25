using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class ProductLineRepository : IProductLineRepository
    {
        private readonly BigCorpContext _context;
        private readonly IMapper _mapper;

        public ProductLineRepository(BigCorpContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> addProductLineAsync(ProductLineModel model)
        {
            var newProductLine = _mapper.Map<ProductLine>(model);
            _context.ProductLines.Add(newProductLine);
            await _context.SaveChangesAsync();
            return newProductLine.id;
        }

        public async Task deleteProductLineAsync(int id)
        {
            var deleteProductLine = _context.ProductLines!.SingleOrDefault(b => b.id == id);
            if (deleteProductLine != null)
            {
                _context.ProductLines.Remove(deleteProductLine);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ProductLineModel> getProductLineAsync(int id)
        {
            var productLine = await _context.ProductLines!.FindAsync(id);
            return _mapper.Map<ProductLineModel>(productLine);
        }

        public async Task<List<ProductLineModel>> getProductLinesAsync()
        {
            var productLines = await _context.ProductLines!.ToListAsync();
            return _mapper.Map<List<ProductLineModel>>(productLines);
        }

        public async Task updateProductLineAsync(int id, ProductLineModel model)
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
