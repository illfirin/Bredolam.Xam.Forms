using System;
using System.Collections.Generic;
using moback;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;


namespace NavDrawer.Forms
{
    public class Search: ContentPage
    {
        public Search()
        {
            Entry request = new Entry();
            Button beginSearch = new Button
            {
                Text = "Search";
            };


            beginSearch.Clicked +=  (sender, e) =>
            {

            };


            
        }
        async Task<List<Item>> GetSearchedArray(string str)
        {
            //searched pattern

            string pattern = @"\b(\w+)\s\1\b";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

            //get objects, that match the pattern
            
            return await Task.Run(() =>
            {
            List<Item> l = new List<Item>)();
            mobackObject[] obj = localClient.GetObjectWithQuery("Citate", new { Content = reg.Match(str) });
            foreach (mobackObject mb in obj)
            {

                l.Add(mobackStorageImpl.FrommobackObject(mb));
            }
            return l;
        });
               
            }
}
}