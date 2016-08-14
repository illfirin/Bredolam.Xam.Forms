using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using moback;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NavDrawer.Forms
{
    public class AddNew : ContentPage
    {
        public AddNew(Item item)
        {
            Label Autor = "Автор";
            Entry autor = new Entry();
            Label Name = "Название цитаты";
            Entry name = new Entry();
            Label Content = "Сама цитата";
            Entry content = new Entry();
            Label Tags = "Введите теги через пробел";
            Entry tags = new Entry();

            Button Save = new Button
            {
                Text = "Save";
            BackgroundColor = Colors.GetColor(Colors.Wired);

        }
        Save.Clicked += (senser, e) =>
            {
             
                String[] tags = (tags.Text).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        resultObject ro = new resultObject();
        mobackObject mObject = new mobackObject("Citate");
        mObject["Author"] = autor.Text;
                mObject["Content"] = content.Text;
                mObject["Name"] = name.Text;
                mObject["tags"] = tags;

                if(MainPage.HasConnection())
                {
                    try
                    {
                        ro = localClient.UpdateObject(mObject);
                    }
                    catch(Exception ex)
                    {
                        Console.Error.WriteLine(@"Error{0}", ex.Message);
                    }
               
            }
        }
    }
}