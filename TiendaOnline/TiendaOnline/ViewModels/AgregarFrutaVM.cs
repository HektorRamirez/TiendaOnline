using Akavache;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TiendaOnline.Models;
using Xamarin.Forms;

namespace TiendaOnline.ViewModels
{
	public class AgregarFrutaVM:BaseViewModel
	{
		#region Variables

		int cantidad;
		string precio;
		public int CantidadCompra { get; set; }
		public string Nombre { get; set; }
		public string Precio { get; set; }
		public string Caducidad { get; set; }
        public int IdProducto { get; set; }
        private readonly APIS apis;
		#endregion

		#region Constructor

		public AgregarFrutaVM()
        {
			apis = new APIS();
			EnviarCompraCommand = new Command(async () => await AgregarProducto());
		}

		#endregion

		#region Objetos
		public int Cantidad
		{
			get { return cantidad; }
			set { SetValue(ref cantidad, value); }
		}

		#endregion

		#region Funciones
		public async Task AgregarProducto()
		{
			Nombre = "Lata de frutas";
			Precio = "105";
			Caducidad = "18/Agosto/2028";
			IdProducto = 3;
			if (cantidad == 0)
			{
				Cantidad = 1;
			}

			try
			{
				var compra = new DetalleCompra
				{
					Cantidad = CantidadCompra,
					PrecioCompra = Precio.ToString(),
					FechaCaducidad = Caducidad.ToString(),
					IdProducto = IdProducto
				};
				var exito = await apis.EnviarCompras(compra);

				if (exito)
				{
					await Application.Current.MainPage.DisplayAlert("Éxito", "Compra enviada correctamente", "OK");
					int Precio3 = 58;
					await BlobCache.UserAccount.InsertObject("Producto3", Nombre);
					await BlobCache.UserAccount.InsertObject("Precio3", Precio3);
					await BlobCache.UserAccount.InsertObject("Cantidad3", Cantidad);
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("Error", "No se pudo agregar el producto al carrito", "OK");
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}
		#endregion

		#region Commandos
		public ICommand EnviarCompraCommand { get; }
		#endregion
	}
}
