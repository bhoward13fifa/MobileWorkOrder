using System.Collections.Generic;
using System.Threading.Tasks;
using TestWO.Models;

namespace TestWO.Services
{
    public interface IDataStore<Item>
    {
        Task<bool> AddItemAsync(Item item);
        Task<bool> DeleteItemAsync(string id);
        Task<Item> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> UpdateItemAsync(Item item);
    }
}