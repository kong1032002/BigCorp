using BigCorp.Datas;
using BigCorp.Models;

namespace BigCorp.Repository.Interface
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> getProductsAsync();
        public Task<ProductModel> getProductAsync(int id);
        public Task<int> addProductAsync(ProductModel model);
        public Task updateProductAsync(int id, ProductModel model);
        public Task removeStorageAsync(int id);
    }
}
