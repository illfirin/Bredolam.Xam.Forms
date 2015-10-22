using System;
using Parse;
using Xamarin.Forms.Platform.Android;
using Android.Content.PM;
using Android.App;
using Android.OS;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace NavDrawer.Forms
{
	[Activity(Label = "NavDrawer", MainLauncher = true,
		ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
	    public class MainActivity : FormsApplicationActivity {

		public static MainActivity Current { get; private set; }
		public NavDrawer.Forms.ParseStorageImpl TaskMgr { get; set; }

		public MainActivity(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
				: base() {
				Current = this;
			}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);
			TaskMgr = ParseStorageImpl.Default;
			Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new Appl());
		}
	}


	public class Appl: Xamarin.Forms.Application
	{
		public Appl ()
		{
			/*var masterDetail = new MasterDetailPage ();
			var master = new MenuPage (masterDetail);

			masterDetail.Master = master;
			master.Selected (MenuOption.Home);*/

			var menuPage = new MenuPage();
		
		}
	}



}
	


