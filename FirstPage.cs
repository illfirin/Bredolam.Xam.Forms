using System;
using System.Collections.Generic;
using moback;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace NavDrawer.Forms
{
    public class FirstPage : ContentPage
    {
        public FirstPage()
        {
            Entry _search = new Entry { Placeholder = "Enter your request here"};
            var layout = new StackLayout();
            Button lDay = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Show citations for the last day",
                BackgroundColor = Colors.GetColor(Colors.Esmeralda_eyes)
            };

            Button lWeek = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Show citations for the last week",
                BackgroundColor = Colors.GetColor(Colors.Esmeralda_eyes)
            };

            Button lmonth = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Show citations for the last month",
                BackgroundColor = Colors.GetColor(Colors.Esmeralda_eyes)
            };

            lDay.Clicked += (sender, e) =>
                {
                    mobackObject[] obj = localClient.GetObjectsWithQuery("Citate", new { createdAt = DateTime.Today});
                    List<CitateCell> cit = new List<CitateCell>();
                    List<Item> it = new List<Item>();
                    foreach(var b in obj)
                    {
                        cit.Add(it.Add(mobackStorageImpl.Frommobackobj(b)));

                    }
                    foreach(var c in cit)
                    {
                        layout.Children.Add(c);
                    }
                };
            lWeek.Clicked += (sender, e) =>
                {
                    //get list of citations with LINQ
                    mobackObject[] obj = localClient.GetObjectsWithQuery("Citate", new  cit.Where(t => createdAt >= DateTime.Now.AddDays(-7) ));
                    List<CitateCell> cit = new List<CitateCell>();
                    List<Item> it = new List<Item>();
                    foreach (var b in obj)
                    {
                        cit.Add(it.Add(mobackStorageImpl.Frommobackobj(b)));

                    }
                    foreach (var c in cit)
                    {
                        //add citations
                        layout.Children.Add(c);
                    }
                };
            lmonth.Clicked += (sender, e) =>
            {
                mobackObject[] obj = localClient.GetObjectsWithQuery("Citate", new cit.Where(t => createdAt >= DateTime.Now.AddMonth(-1)));
                List<CitateCell> cit = new List<CitateCell>();
                List<Item> citates = new List<Item>();

                foreach(var b in obj)
                {
                    citates.Add(it.Add(mobackStorageImpl.Frommobackobj(b)));
                }

                foreach(var c in citate)
                {
                
                    layout.Children.Add(c);
                }
            }

            this.Content = new StackLayout
            {
                BackgroundColor = Color.FromHex("#ECE5CE"),
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = 
                {
                    _search,
                    lDay,
                    lWeek,
                    lmonth
                };
                
            };

            


    }
}
