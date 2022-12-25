using BigCorp.Models;

namespace BigCorp.Repository.Interface
{
    public interface IStockRepository
    {
        public Task<List<StockModel>> getStocksAsync();
        public Task<StockModel> getStockAsync(int id);
        public Task<int> addStockAsync(StockModel model);
        public Task updateStockAsync(int id, StockModel model);
        public Task deleteStockAsync(int id);

    }
}
