using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaOnline.ViewModels
{
	public class ProductosVM
	{
        #region Variables

        #endregion

        #region Constructor
        public ProductosVM()
        {
            
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

		#endregion

		#region Comandos

		#endregion

	}
}
