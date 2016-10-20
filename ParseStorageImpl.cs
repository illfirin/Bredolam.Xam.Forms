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

        public mobackObject TomobackObject(Item item)
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
        public static Item FrommobackObject(mobackObject po)
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

        async public Task<List<Item>> RefreshDataAsync(Item item)
        {
           // var query = ParseObject.GetQuery("Citate").OrderBy("Name");
            mobackObject[] obj = localClient.GetObjectsWithQuery("Citate", new { CitateName = "Name" });
            //var ie = await obj.FindAsync();
            resultObject ro = new resultObject();
            /*mobackObject newObject = new mobackObject("Employees");
            newObject["Citate"] = "NewName"
            var items = new List<Item>();*/
            foreach (var t in obj)
            {
                ro = localClient.UpdateObject(obj));
            }

            return items;*/
        }
        public async Task DeleteItemAsync(string name)
        {
            try
            {
                mobackObject[] mo = localClient.GetObjectsWithQuery("Citate", new { Name = name });
                foreach (mobackObject mb in mo)
                {
                    localClient.DeleteObject(mb);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(@"Error{0}", ex.Message);
            }
        }

        public async Task SaveItemAsync(Item item)
        {
            //await ToParseObject(item).SaveAsync();
        }
        public async Task RefreshUserData(moback.mobackUser user)
        {
            //Connection to moback, creation of new object that will be sent
            moback.mobackObject userObj = new moback.mobackObject(user[user.Name]);
            userObj[userObj.userId] = userObj.userId;
            userObj["Name"] = user.Name;
            appUSer appuser = new appUSer();
            appuser.userId = user.Id;

            //Updating user data
            appuser.password = user.password;
            try
            {
                var vsessionToken = mu.Login(appuser);
                resultObject ro = new resultObject();
                ro = mu.userUpdate(userObj, vsessionToken.ssotoken);
            }

            catch(exception ex)
            {

            }

        }

        public static T RefreshContent(string txt, string colour)
        {
            //creating new generic exemplar and write data into it
            T cont = new T();
            cont.Text = txt;
            cont.BackgroundColor = colour;
            
            return cont;
        
        }
        

            

        }
}

