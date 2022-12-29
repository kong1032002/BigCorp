namespace BigCorp.Repository.Interface
{
    public interface IItemRepository<V, T>
    {
        public Task<T> GetItemAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task AddItemAsync(V model);
        public Task RemoveItemAsync(int id);
        public Task UpdateItemAsync(int id, V model);
        public bool ItemExists(int id);
    }
}
