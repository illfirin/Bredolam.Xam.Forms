using System;
using NavDrawer.Forms;
using Android;
using Xamarin.Forms;
using System.Net.WebClient;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Parse;
using Android.App;
using System.Net;
using System.Collections.Generic;

namespace NavDrawer.Forms
{
    public class Favorites:NavigationPage
    {
        public Favorites()
        {
            ParseUser user = ParseUser.CurrentUser;
            Collection<Item> favorites = (System.Collections.ObjectModel.Collection<NavDrawer.Forms.Item>)user["Favorites"];
            TextCell[] _text = new TextCell[0];
            for(int i = 0;  i < _text.Length; i++ )
            {
                foreach(var f in favorites)
                {
                    _text[i].Text = f.Name;
                    _text[i].Detail = f.Content;
                }
            }

        }


    }
}