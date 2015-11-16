using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace NavDrawer.Forms
{
	public class ItemCytateManager
	{
		IParseStorage storage;

		public ItemCytateManager (IParseStorage storage)
		{
			this.storage = storage;
		}

        public Task<Item> GetTaskAsync(string id)
        {
            return storage.GetItemAsync(id);
        }

        public Task<List<Item>> GetTaskAsync()
        {
            return storage.RefreshDataAsync();
        }
        public Task SaveTaskAsync (Item item)
        {
            return storage.SaveItemAsync(item);
        }
        public Task DeleteTaskAsync(Item item)
        {
            return storage.DeleteItemAsync(item);
        }

	}
}

