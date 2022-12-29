using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class StockRepository : IItemRepository<StockModel, Stock>
    {
        private readonly IMapper _mapper;
        private readonly BigCorpContext _context;

        public StockRepository(BigCorpContext context, IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddItemAsync(StockModel model)
        {
            var stock = _mapper.Map<Stock>(model);
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int Id)
        {
            var stock = await GetItemAsync(Id);
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int Id, StockModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Stock> GetItemAsync(int Id)
        {
            return await _context.Stocks.FindAsync(Id);
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public bool ItemExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
}
