using System;
using moback;
using Quickblox.Sdk;
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
        public List<mobackUser> Added { get; set; }
    }

    public interface IParseStorage
    {
        Task<List<Item>> RefreshDataAsync();
        Task<Item> GetItemAsync(string id);
        Task SaveItemAsync(Item item);
        Task DeleteItemAsync(Item item);
    }
    public class mobackStorageImpl : IParseStorage
    {
        static mobackStorageImpl impl = new mobackStorageImpl();
        public static mobackStorageImpl Default { get { return impl; } }
        mobackClient localClient = new mobackClient(ApplicationKeyId: "YTRkZDRjZTUtMDVhMi00NTZkLWFhMjUtMWRlNTc1YzFlYmIx", DevelopmentKey: "YTVlZDE3NWQtZGZmMS00MmE2LWJiODMtYTIxOTZlMTViZjA2", baseurl: "https://api.moback.com");
        public List<Item> Items { get; private set; }
        protected mobackStorageImpl()
        {
            Items = new List<Item>();
        }

        mobackObject TomobackObject(Item item)
        {
            var po = new mobackObject("Citate");
            if (item.Id != 0)
                po.objectId = Convert.ToString(item.Id);

            po["Author"] = item.Author;
            po["Name"] = item.Name;
            po["Rating"] = item.rating;
            po["Tags"] = item.tags;
            po["Content"] = item.Content;
            po["Added"] = item.Added;
            return po;
        }
        Item FromParseObject(mobackObject po)
        {
            var i = new Item();
            i.Id = Convert.ToInt32(po.objectId);
            i.rating = Convert.ToInt32(po["Rating"]);
            i.Author = Convert.ToString(po["Author"]);
            i.Name = Convert.ToString(po["Name"]);
            i.tags = (List<string>)po["Tags"];
            i.Content = Convert.ToString(po["Content"]);
            i.Added = (List<mobackUser>)po["Added"];
            return i;
        }

        async public Task<List<Item>> RefreshDataAsync()
        {
           // var query = ParseObject.GetQuery("Citate").OrderBy("Name");
            mobackObject[] obj = localClient.GetObjectsWithQuery("Citates", new { CitateName = "Name" });
            //var ie = await obj.FindAsync();
            
            var items = new List<Item>();
            /*foreach (var t in ie)
            {
                items.Add(FromParseObject(t));
            }

            return items;*/
        }

        public async Task SaveItemAsync(Item item)
        {
            //await ToParseObject(item).SaveAsync();
        }

        public async Task<Item> GetItemAsync(string id)
        {
           // var query = ParseObject.GetQuery("Citate").WhereEqualTo("objectId", id);
           // var t = await query.FirstAsync();
           // return FromParseObject(t);
            
        }
        public async Task DeleteItemAsync(Item item)
        {
            try
            {
              //  await ToParseObject(item).DeleteAsync();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(@"Error{0}", ex.Message);
            }
        }
    }
}

