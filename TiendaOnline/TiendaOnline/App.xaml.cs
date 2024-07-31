using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TiendaOnline.Views;
namespace TiendaOnline
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new Productos());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
