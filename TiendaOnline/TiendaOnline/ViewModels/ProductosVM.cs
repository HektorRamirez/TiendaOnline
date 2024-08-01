using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TiendaOnline.Views;
using Xamarin.Forms;

namespace TiendaOnline.ViewModels
{
	public class ProductosVM:BaseViewModel
	{
        #region Variables

        #endregion

        #region Constructor
        public ProductosVM()
        {
			IrCommandLeche = new Command(IrACarroDeComprasLeche);
			IrCommandCereal = new Command(IrACarroDeComprasCereal);
			IrCommandFrutas = new Command(IrACarroDeComprasLataFrutas);
			IrCommandCarro = new Command(IrACarro);
		}
        #endregion

        #region Objetos
        public string Precio { get; set; }
        public DateTime FechaCaducidad { get; set; }


		private string nombreProducto;

		public string NombreProducto
		{
			get { return nombreProducto; }
			set { nombreProducto = value; }
		}

		private string precioProducto;

		public string PrecioProducto
		{
			get { return precioProducto; }
			set { precioProducto = value; }
		}

		#endregion

		#region Funciones
		private async void IrACarroDeComprasLeche()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new LecheCarrito());
		}

		private async void IrACarroDeComprasCereal()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new CerealCarrito());
		}

		private async void IrACarroDeComprasLataFrutas()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new FrutasCarritos());
		}

		private async void IrACarro()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new Carrito());
		}
		#endregion

		#region Comandos
		public ICommand IrCommandLeche { get; }
		public ICommand IrCommandCereal { get; }
		public ICommand IrCommandFrutas { get; }
		public ICommand IrCommandCarro { get; }
		#endregion

	}
}
