using Akavache;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TiendaOnline.Models;
using TiendaOnline.Views;
using Xamarin.Forms;

namespace TiendaOnline.ViewModels
{
    public class CarritoVM: BaseViewModel
    {
		#region Variables
		public ObservableCollection<CarritoTotal> Carrito { get; set; }
		public ICommand AgregarProductoCommand { get; }
		#endregion

		#region Constructor
		public CarritoVM()
        {
			Carrito = new ObservableCollection<CarritoTotal>();
			CalcularSumaCommand = new Command(async () => await CalcularSuma());
		}
		#endregion

		#region Objetos
		private int suma;
		public int Suma
		{
			get => suma;
			set => SetProperty(ref suma, value);
		}
		#endregion

		#region Funciones
		private async Task CalcularSuma()
		{
			try
			{
				int precio1 = await BlobCache.UserAccount.GetObject<int>("Precio1");
				int precio2 = await BlobCache.UserAccount.GetObject<int>("Precio2");
				int precio3 = await BlobCache.UserAccount.GetObject<int>("Precio3");

				Suma = precio1 + precio2;
			}
			catch (Exception ex) 
			{
				Suma = 0;
			}
		}

		public ICommand CalcularSumaCommand { get; }
		#endregion
	}
}
