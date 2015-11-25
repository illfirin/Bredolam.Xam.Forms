using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Parse;
namespace NavDrawer.Forms
{
	public class MenuPage : ContentPage
	{
		
		ObservableCollection<MenuItem> Items;
		private readonly MasterDetailPage master;
		private NavigationPage home;
		private NavigationPage addNew;
		private NavigationPage profile;
        private NavigationPage Favorites;
        private NavigationPage Settings;
        private NavigationPage Exit;


		public MenuPage (MasterDetailPage masterDetail)
		{
			Items = new ObservableCollection<MenuItem> ();
			Items.Add (new MenuItem{ Title = "На главную", Option = MenuOption.Home });
			Items.Add (new MenuItem{ Title = "Добавить новую", Option = MenuOption.Add_new });
			Items.Add (new MenuItem{ Title = "Профиль", Option = MenuOption.Profile });
            Items.Add(new MenuItem { Title = "Избранное", Option = MenuOption.Favorites });
            Items.Add(new MenuItem { Title = "Настройки", Option = MenuOption.Settings });
            Items.Add(new MenuItem { Title = "Выход", Option = MenuOption.Exit });

            master = masterDetail;

			Title = "menu";
			Icon = "ic_drawer_dark.png";
			BackgroundColor = Color.FromHex ("111111");

			var listView = new ListView {
				RowHeight = 60,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate (typeof(MenuCell)),
				ItemsSource = Items
			};

			listView.ItemSelected += (sender, e) => {

				var item = e.SelectedItem as MenuItem;
				if (item == null)
					return;

				Selected (item.Option);

				listView.SelectedItem = null;//clear out
			};

			Content = listView;
		}

        public void Selected(MenuOption item)
        {
            master.IsPresented = false; // close the slide-out

            switch (item)
            {
                case MenuOption.Home:
                    master.Detail = home ??
                    (home = new NavigationPage(
                        new ContentPage
                        {
                            Title = "Home",
                            Content = new Label { Text = "Home", Font = Font.SystemFontOfSize(40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }
                        })
                    );
                    break;
                case MenuOption.Profile:
                    master.Detail = profile ??
                    (profile = new NavigationPage(
                        new ContentPage
                        {
                            Title = "Profile",
                            Content = new Label { Text = "Profile", Font = Font.SystemFontOfSize(40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }
                        })
                    );
                    break;
                case MenuOption.Add_new:
                    master.Detail = addNew ??
                    (addNew = new NavigationPage(
                        new ContentPage
                        {
                            Title = "Add New",
                            Content = new Label { Text = "Add new", Font = Font.SystemFontOfSize(40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }
                        })
                    );
                    break;
                case MenuOption.Favorites:
                    master.Detail = Favorites ??
                        (Favorites = new NavigationPage(
                            new ContentPage
                            {
                                Title = "Favotites",
                                Content = new Label { Text = "Favorites", Font = Font.SystemFontOfSize(40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }
                            }));
                    break;
                case MenuOption.Exit:
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");
                        if (result) Android.OS.Process.KillProcess(Android.OS.Process.MyPid());  
                    });
                    break;




            }
        }

        
	}
	

}

