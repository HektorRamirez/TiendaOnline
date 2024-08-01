using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TiendaOnline.Models;
using Xamarin.Forms;
using Akavache;
using System.Reactive.Linq;
using System.Security.Principal;

namespace TiendaOnline.ViewModels
{
	public class AgregarCerealVM:BaseViewModel
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

        public AgregarCerealVM()
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
			Nombre = "Cereal de maiz";
			Precio = "32";
			Caducidad = "01/Junio/2025";
			IdProducto = 2;

			if (cantidad == 0)
			{
				Cantidad = 1;
			}

			try
			{
				var compra = new DetalleCompra
				{
					Cantidad = Cantidad,
					PrecioCompra = Precio.ToString(),
					FechaCaducidad = Caducidad.ToString(),
					IdProducto = IdProducto
				};
				var exito = await apis.EnviarCompras(compra);

				if (exito)
				{
					await Application.Current.MainPage.DisplayAlert("Éxito", "Compra enviada correctamente", "OK");
					int Precio2 = 55;
					await BlobCache.UserAccount.InsertObject("Producto2", Nombre);
					await BlobCache.UserAccount.InsertObject("Precio2", Precio2);
					await BlobCache.UserAccount.InsertObject("Cantidad2", Cantidad);
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

		#region Comandos
		public ICommand EnviarCompraCommand { get; }
		#endregion

	}
}
