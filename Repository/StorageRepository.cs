using AutoMapper;
using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigCorp.Repository
{
    public class StorageRepository : IItemRepository<StorageModel>
    {
        private readonly BigCorpContext _context;
        private readonly IMapper _mapper;

        public StorageRepository(BigCorpContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddItemAsync(StorageModel model)
        {
            var newSlot = _mapper.Map<Storage>(model);
            _context.Storages.Add(newSlot);
            await _context.SaveChangesAsync();
            return newSlot.id;
        }

        public async Task<List<StorageModel>> GetAllAsync()
        {
            var storages = await _context.Storages!.ToListAsync();
            return _mapper.Map<List<StorageModel>>(storages);
        }

        public async Task<StorageModel> GetItemAsync(int id)
        {
            var storage = await _context.Storages!.FindAsync(id);
            return _mapper.Map<StorageModel>(storage);
        }

        public async Task RemoveItemAsync(int id)
        {
            var removeStorage = _context.Storages!.SingleOrDefault(b => b.id == id);
            if (removeStorage != null)
            {
                _context.Storages!.Remove(removeStorage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateItemAsync(int id, StorageModel model)
        {
            if (id == model.product.id)
            {
                var updateStorage = _mapper.Map<Storage>(model);
                _context.Storages!.Update(updateStorage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
