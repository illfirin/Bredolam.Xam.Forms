using System;
using System;
using NavDrawer.Forms;
using Android;
using Xamarin.Forms;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Parse;
using Android.App; 

namespace NavDrawer.Forms
{
	public class MainPage: ContentPage
	{
		public MainPage ()
		{
			Button EnterButton = new Button {
				Text = "Вход",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.GetColor (Colors.White)

			};
			Button RegistrationButton = new Button {
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
			Button EntrButton = new Button {
				Text = "Login",
				BackgroundColor = Colors.GetColor(Colors.Therapy)
			};
			EntrButton.Clicked += async (sender,e) =>
			{
				if(user.Text != (null || "") || pass.Text != (null ||""))
					{
						ParseUser.SignUpAsync(user.Text, pass.Text);
					}
				else if( user.Text != (null || "") || pass.Text != (null ||""))
				{
					_label.Text = "Должны быть заполнены оба поля";
				}
				else
				{
					throw new Exception("Низвестая ошибка");
				}

			};
			Entry user = new Entry { Placeholder = "Username" };
			Entry pass = new Entry { Placeholder = "Password" };
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
	public class RegistrationPage:ContentPage 
	{
		public RegistrationPage()
		{
			Button button = new Button 
			{
				Text = "Registration",
				BackgroundColor = Colors.GetColor (Colors.Esmeralda_eyes)
			};

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
					await ParseUser.SignUpAsync(user.Username, user.Password);
				}
				catch(Exception ex)
				{
					var builder = new AlertDialog.Builder(this);
					builder.SetMessage(ex.ToString());
					builder.SetPositiveButton("OK", (s, e) => {});
				}
			};
			async Task SignUpUserCommand ()
			{ 
				{ if (IsBusy) { return; }
					IsBusy = true;
					try 
					{
						var user = new ParseUser()
						{ 
							Username = userName.Text,
							Email = email.Text,
							Password = pass.Text
						};

						var connected = CrossConnectivity.Current.IsConnected;
						if (connected) 
						{ 
							UserDialogs.Instance.ShowLoading ("Creating Account");
							//The code that actually signs a user up! 
							await user.SignUpAsync();
							//More UI stuff.. 
							UserDialogs.Instance.HideLoading ();
							await NavigateToMainUI (); 
						} 
						else { UserDialogs.Instance.ShowError ("No Internet Connection"); } }
					catch (Exception ex) 
					{ 
						UserDialogs.Instance.ShowError(ex.Message, 3); Xamarin.Insights.Report (ex); }
						IsBusy = false; 
					} 

				
			}


			Entry email = new Entry {Placeholder = "Эл.Почта"};
			Entry userName = new Entry{ Placeholder = "Логин"};
			Entry pass = new Entry { Placeholder = "Пароль" };
		}

	}
}

