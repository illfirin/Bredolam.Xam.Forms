using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using moback;

namespace NavDrawer.Forms
{
    public class CitatePage: ContentPage
    {
        public CitatePage(Item item)
        {
            //Is citation rate added by user?
            bool _added = false;
            Label title = new Label();
            title.Text = item.Name;

            Label tags = new Label();
            foreach (var tag in item.tags)
            {
                tags.Text += tag + " ";
            }
            Label author = new Label();
            author.Text = item.Author;

            Label _citate = new Label();
            _citate.Text = item.Content;

            Label rating = new Label();
            rating.Text = Convert.ToString(item.rating);

            Button addRate = new Button();
            addRate.Text = "+";
            addRate.TextColor = Color.FromHex(Colors.Therapy);
            Label btnText = new Label();
            btnText.Text = "Add to favorites";
         

            var add = from user in item.Added
                      where user == ParseUser.CurrentUser
                      select user;
            if (add != null)
                _added = true; 

            addRate.Clicked += (sender, e) =>
                {
                    if(_added != true)
                    {
                        item.rating += 1;
                        item.Added.Add();
                        addRate.TextColor = Color.FromHex(Colors.Wired);
                        _added = true;
                    }
                };

            StackLayout rate = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    rating,
                    addRate
                }

            };
            this.Content = new StackLayout
            {
                BackgroundColor = Color.FromHex("#ECE5CE"),
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = 
                {
                    title,
                    author,
                    tags,
                    rate
                }
            };
            
        }
    }
}