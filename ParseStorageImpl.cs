using System;
using Parse;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NavDrawer.Forms
{
    public class Item
    {
        public Item()
        {
            Id = this.Id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int rating { get; set; }

        public List<string> tags { get; set; }
    }

    public interface IParseStorage
    {
        Task<List<Item>> RefreshDataAsync();
        Task<Item> GetItemAsync(string id);
        Task SaveItemAsync(Item item);
        Task DeleteItemAsync(Item item);
    }
    public class ParseStorageImpl : IParseStorage
    {
        static ParseStorageImpl impl = new ParseStorageImpl();
        public static ParseStorageImpl Default { get { return impl; } }
        public List<Item> Items { get; private set; }
        protected ParseStorageImpl()
        {
            Items = new List<Item>();
            ParseClient.Initialize("OPoI08dUl7lehA2pjyHUmliYpLr6VpOxM2hKZaGu", "o5NPUXwwz148AJw8QN64m7rCiGLa4Kh19tOmmDZz");
        }

        ParseObject ToParseObject(Item item)
        {
            var po = new ParseObject("Citate");
            if (item.Id != 0)
                po.ObjectId = Convert.ToString(item.Id);

            po["Author"] = item.Author;
            po["Name"] = item.Name;
            po["Rating"] = item.rating;
            po["Tags"] = item.tags;
            po["Content"] = item.Content;

            return po;
        }
        Item FromParseObject(ParseObject po)
        {
            var i = new Item();
            i.Id = Convert.ToInt32(po.ObjectId);
            i.rating = Convert.ToInt32(po["Rating"]);
            i.Author = Convert.ToString(po["Author"]);
            i.Name = Convert.ToString(po["Name"]);
            i.tags = (List<string>)po["Tags"];
            i.Content = Convert.ToString(po["Content"]);

            return i;
        }

        async public Task<List<Item>> RefreshDataAsync()
        {
            var query = ParseObject.GetQuery("Citate").OrderBy("Name");
            var ie = await query.FindAsync();

            var items = new List<Item>();
            foreach (var t in ie)
            {
                items.Add(FromParseObject(t));
            }

            return items;
        }

        public async Task SaveItemAsync(Item item)
        {
            await ToParseObject(item).SaveAsync();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var query = ParseObject.GetQuery("Citate").WhereEqualTo("objectId", id);
            var t = await query.FirstAsync();
            return FromParseObject(t);
            
        }
        public async Task DeleteItemAsync(Item item)
        {
            try
            {
                await ToParseObject(item).DeleteAsync();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(@"Error{0}", ex.Message);
            }
        }
    }
}

