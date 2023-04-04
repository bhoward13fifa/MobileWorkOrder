using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWO.Models;

namespace TestWO.Services
{
    //public class MockDataStore : IDataStore<ViewWorkOrderModel>
    //{
    //    readonly List<ViewWorkOrderModel> items;

    //    public MockDataStore()
    //    {
    //        items = new List<ViewWorkOrderModel>()
    //        {
    //            new ViewWorkOrderModel { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
    //            new ViewWorkOrderModel { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
    //            new ViewWorkOrderModel { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
    //            new ViewWorkOrderModel { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
    //            new ViewWorkOrderModel { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
    //            new ViewWorkOrderModel { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
    //        };
    //    }

    //    public async Task<bool> AddItemAsync(ViewWorkOrderModel item)
    //    {
    //        items.Add(item);

    //        return await Task.FromResult(true);
    //    }

    //    public async Task<bool> UpdateItemAsync(ViewWorkOrderModel item)
    //    {
    //        var oldItem = items.Where((ViewWorkOrderModel arg) => arg.Id == item.Id).FirstOrDefault();
    //        items.Remove(oldItem);
    //        items.Add(item);

    //        return await Task.FromResult(true);
    //    }

    //    public async Task<bool> DeleteItemAsync(string id)
    //    {
    //        var oldItem = items.Where((ViewWorkOrderModel arg) => arg.Id == id).FirstOrDefault();
    //        items.Remove(oldItem);

    //        return await Task.FromResult(true);
    //    }

    //    public async Task<ViewWorkOrderModel> GetItemAsync(string id)
    //    {
    //        return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
    //    }

    //    public async Task<IEnumerable<ViewWorkOrderModel>> GetItemsAsync(bool forceRefresh = false)
    //    {
    //        return await Task.FromResult(items);
    //    }
    //}
}