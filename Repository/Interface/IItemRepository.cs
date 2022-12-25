namespace BigCorp.Repository.Interface
{
    public interface IItemRepository<T>
    {
        public Task<T> GetItemAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task<int> AddItemAsync(T model);
        public Task RemoveItemAsync(int id);
        public Task UpdateItemAsync(int id, T model);
    }
}
