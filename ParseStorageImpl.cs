using System;
using Parse;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NavDrawer.Forms
{
	public class ParseStorageImpl
	{
		static ParseStorageImpl impl = new ParseStorageImpl();
		public static ParseStorageImpl Default {get {return impl;}}
		protected ParseStorageImpl ()
		{
			ParseClient.Initialize ("OPoI08dUl7lehA2pjyHUmliYpLr6VpOxM2hKZaGu", "o5NPUXwwz148AJw8QN64m7rCiGLa4Kh19tOmmDZz");
		}
	}
	public interface IParseStorage
	{
		Task<List<Item>> RefreshDataAsync();
		Task<Item> GetItemAsync(string id);
		Task SaveItemAsync(Item item);
		Task DeleteItemAsync (string id);
	}

	public class Item
	{
		public Item (){}
		public int Id {get; set;}
		public string Name { get; set; }
		public string Author { get; set; }
	}


}

