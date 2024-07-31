using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnline.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaOnline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FrutasCarritos : ContentPage
	{
		public FrutasCarritos()
		{
			InitializeComponent();
			BindingContext = new AgregarFrutaVM();
		}
	}
}