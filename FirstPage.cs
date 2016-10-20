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
            var layout = new StackLayout();
            Button lDay = new Button
            {

            };

            Button lWeek = new Button
            {

            };

            Button lmonth = new Button
            {

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
                    mobackObject[] obj = localClient.GetObjectsWithQuery("Citate", new { createdAt = System.DateTime.Now) });
                    List<CitateCell> cit = new List<CitateCell>();
                    List<Item> it = new List<Item>();
                    foreach (var b in obj)
                    {
                        cit.Add(it.Add(mobackStorageImpl.Frommobackobj(b)));

                    }
                    foreach (var c in cit)
                    {
                        layout.Children.Add(c);
                    }
                };
            lmonth.Clicked += (sender, e) =>
            {
                mobackObject[] obj = localClient.GetObjectsWithQuery("Citate", new {createdAt = })
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
                    
                }
                
            }

            


    }
}
