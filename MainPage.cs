using System;
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

namespace NavDrawer.Forms
{
   
	public class MainPage: ContentPage
	{
		public MainPage ()
		{
			Button EnterButton = new Button 
            {
				Text = "Вход",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.GetColor (Colors.White)

			};

			Button RegistrationButton = new Button 
            {
				Text = "Регистрация",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.GetColor (Colors.White)
			};

			EnterButton.Clicked += async(sender,  e) => 
			{
				var enPage = new EnterPage();
				await Navigation.PushModalAsync(enPage);

			};	

			RegistrationButton.Clicked += async (sender,  e) => 
			{
				var regPage = new RegistrationPage();
				await Navigation.PushAsync(regPage);

			};
	
            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.GetColor(Colors.Wired),
                Children = {EnterButton, RegistrationButton}
            };

		}
	}

	public class EnterPage:ContentPage
	{
		Label _label = new Label
		{
			VerticalOptions = LayoutOptions.Center,
			TextColor = Color.White,
			Font = Device.OnPlatform(Font.OfSize("HelveticaNeue-Thin", 30),
				Font.SystemFontOfSize(25),
				Font.SystemFontOfSize(40))
		};
		public EnterPage() 
        {
		    
            Entry user = new Entry { Placeholder = "Username" };
			Entry pass = new Entry { Placeholder = "Password" };

			Button EntrButton = new Button 
            {
				Text = "Login",
				BackgroundColor = Colors.GetColor(Colors.Therapy)
			};
			EntrButton.Clicked += async (sender,e) =>
			{
				if(String.IsNullOrEmpty(user.Text) != false ||  String.IsNullOrEmpty(pass.Text) != false)
					{
						//
                        _label.Text = "Должны быть заполнены оба поля";
					}
				else if(String.IsNullOrEmpty(user.Text) == false &  String.IsNullOrEmpty(pass.Text) == false)
				{
					await ParseUser.LogInAsync(user.Text, pass.Text);
				}
				else
				{
					throw new Exception("Низвестая ошибка");
				}

			};
			
			this.Content = new StackLayout
			{
				Spacing = 20, Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.GetColor(Colors.Wired),
				Children = 
				{
					
					user ,
					pass,
					EntrButton,
					_label
				}
			};
		
	    }
    }
	public class RegistrationPage: ContentPage 
	{
		public RegistrationPage()
		{
			Button button = new Button 
			{
				Text = "Registration",
				BackgroundColor = Colors.GetColor (Colors.Esmeralda_eyes)
			};

            Entry email = new Entry { Placeholder = "Эл.Почта" };
            Entry userName = new Entry { Placeholder = "Логин" };
            Entry pass = new Entry { Placeholder = "Пароль" };

			button.Clicked += async (sender, e) => 
			{
				try
				{
					var user = new ParseUser
					{
						Username = userName.Text,
						Email = email.Text,
						Password = pass.Text
					};
                    Collection<Item> favorites = new Collection<Item>();
                    user["Favorites"] = favorites;
					await user.SignUpAsync();
				}
				catch(Exception ex)
				{
                    /* Navigation.PushAsync
                           (new NavigationPage(new ContentPage
                       { 
                             Title = "Error",
                            Content = new Label
                        {
                               Text = ex.Message,
                               Font = Font.SystemFontOfSize(40),
                               VerticalOptions = LayoutOptions.Center,
                               HorizontalOptions = LayoutOptions.Center
					    }
                        })); */
                    Console.Error.WriteLine(@"Error{0}", ex.Message);
                    /*var builder = new AlertDialog.Builder(this)
                    
                    .SetMessage(ex)
                    .SetCancelable(false)
                    .SetPositiveButton("ОК", (s, args) => { });

                    var dialog = builder.Create();
                    dialog.Show();*/
				}
			};
			
                
            }
        async void SignUpUserCommand(string userName, string email, string pass)
        {
            if (IsBusy) { return; }
            IsBusy = true;
            try
            {
                var user = new ParseUser()
                {
                    Username = userName,
                    Email = email,
                    Password = pass
                };

                var connected = RegistrationPage.HasConnection();
                if (connected)
                {

                    await user.SignUpAsync();

                    var fPage = new FirstPage();
                    await Navigation.PushModalAsync(fPage);
                }
                else
                {
                    this.Content = new Label()
                    {
                        Text = "Нет подключения к интернету",
                        Font = Font.SystemFontOfSize(40),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center

                    };
                }
            }
            catch (Exception ex)
            {
                /* Navigation.PushAsync
                    (new NavigationPage(new ContentPage
                {
                    Title = "Error",
                    Content = new Label
                {
                    Text = ex.Message,
                    Font = Font.SystemFontOfSize(40),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                }
                })); */
                Console.Error.WriteLine(@"Error{0}", ex.Message);
            }
        }
               public static bool HasConnection()
                {
                    try
                       {
                           using (var client = new WebClient())
                            {
                                using(var stream = client.OpenRead("http://www.google.com"))
                                {
                                    return true;
                                }
                            }

                        }
                    catch
                        {
                            return false;
                        }
                }


			/* case MenuOption.Add_new:
                    master.Detail = addNew ??
                    (addNew = new NavigationPage(
                        new ContentPage
                        {
                            Title = "Add New",
                            Content = new Label { Text = "Add new", Font = Font.SystemFontOfSize(40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
                        }
             */
    
      }
     
}



