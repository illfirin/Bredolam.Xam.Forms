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

		/*public enum MenuOption
		{
			Home,
			Profile,
			Add_new,
			Favorites,
			Settings,
			Exit
		} */
		public MenuPage ()
		{
			Items = new ObservableCollection<MenuItem> ();
			Items.Add (new MenuItem{ Title = "На главную", Option = MenuOption.Home });
			Items.Add (new MenuItem{ Title = "Добавить новую", Option = MenuOption.Friends });
			Items.Add (new MenuItem{ Title = "Профиль", Option = MenuOption.Profile });
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

		public void Selected (MenuOption item)
		{
			master.IsPresented = false; // close the slide-out

			switch (item) {
			case MenuOption.Home:
				master.Detail = home ??
					(home = new NavigationPage(
						new ContentPage 
						{ 
							Title = "Home",
							Content = new Label { Text = "Home", Font = Font.SystemFontOfSize (40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
						})
					);
				break;
			case MenuOption.Friends:
				master.Detail = friends ??
					(friends = new NavigationPage(
						new ContentPage 
						{ 
							Title = "Friends",
							Content = new Label { Text = "Friends", Font = Font.SystemFontOfSize (40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
						})
					);
				break;
			case MenuOption.Profile:
				master.Detail = profile ??
					(profile = new NavigationPage(
						new ContentPage 
						{ 
							Title = "Profile",
							Content = new Label { Text = "Profile", Font = Font.SystemFontOfSize (40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
						})
					);
				break;*/
			Button button = new Button {
				Text = "Test",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center

			};

			button.Clicked += async delegate {
				var testObject = new ParseObject("Test");
				testObject["foo"] = "bar";
				await testObject.SaveAsync();
			};
			this.Content =
			{
				
			}
		}
	

	}
	public class Home:NavigationPage
	{
	}

}

