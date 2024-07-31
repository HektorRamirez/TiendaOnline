using System;
using System.Collections.Generic;
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
			Caducidad = "25/Mayo/2025";

			if (cantidad == 0)
			{
				Cantidad = 1;
			}

			try
			{
				var compra = new DetalleCompra
				{
					Cantidad = CantidadCompra.ToString(),
					PrecioCompra = Precio.ToString(),
					FechaCaducidad = Caducidad.ToString()
				};
				var exito = await apis.EnviarCompras(compra);

				if (exito)
				{
					await Application.Current.MainPage.DisplayAlert("Éxito", "Compra enviada correctamente", "OK");
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
