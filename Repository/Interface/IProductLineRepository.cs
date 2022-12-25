using BigCorp.Models;

namespace BigCorp.Repository.Interface
{
    public interface IProductLineRepository
    {
        public Task<List<ProductLineModel>> getProductLinesAsync();
        public Task<ProductLineModel> getProductLineAsync(int id);
        public Task<int> addProductLineAsync(ProductLineModel model);
        public Task updateProductLineAsync(int id, ProductLineModel model);
        public Task deleteProductLineAsync(int id);
    }
}
