using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class StockRepository : IItemRepository<StockModel>
    {
        private readonly IMapper _mapper;
        private readonly BigCorpContext _context;

        public StockRepository(BigCorpContext context, IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> AddItemAsync(StockModel model)
        {
            var newStock = _mapper.Map<Stock>(model);
            _context.Stocks.Add(newStock);
            await _context.SaveChangesAsync();
            return newStock.id;

        }

        public async Task RemoveItemAsync(int id)
        {
            var deleteStock = _context.Stocks!.SingleOrDefault(b => b.id == id);
            if (deleteStock != null)
            {
                _context.Stocks.Remove(deleteStock);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<StockModel> GetItemAsync(int id)
        {
            var stock = await _context.Stocks!.FindAsync(id);
            return _mapper.Map<StockModel>(stock);
        }

        public async Task<List<StockModel>> GetAllAsync()
        {
            var stocks = await _context.Stocks!.ToListAsync();
            return _mapper.Map<List<StockModel>>(stocks);
        }

        public async Task UpdateItemAsync(int id, StockModel model)
        {
            if(id == model.id)
            {
                var updateStock = _mapper.Map<Stock>(model);
                _context.Stocks!.Update(updateStock);
                await _context.SaveChangesAsync();
            }
        }
    }
}
