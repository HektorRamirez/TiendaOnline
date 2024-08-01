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
	public class AgregarLecheVM:BaseViewModel
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
        public AgregarLecheVM()
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
			Nombre = "Leche";
			Precio = "25";
			Caducidad = "12/Mayo2025";
			IdProducto = 1;
			if (Cantidad == 0)
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
					IdProducto=IdProducto,
				};
				var exito = await apis.EnviarCompras(compra);

				if (exito)
				{
					await Application.Current.MainPage.DisplayAlert("Éxito", "Compra enviada correctamente", "OK");
					int Precio1 = 25;
					await BlobCache.UserAccount.InsertObject("Producto1", Nombre);
					await BlobCache.UserAccount.InsertObject("Precio1", Precio1);
					await BlobCache.UserAccount.InsertObject("Cantidad1", Cantidad);
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
