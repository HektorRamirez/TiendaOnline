using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TiendaOnline.Models
{
	public class DetalleCompra
	{
        public int Cantidad { get; set; }
        public string PrecioCompra { get; set; }
        public string FechaCaducidad { get; set; }
        public int IdProducto { get; set; }
    }
}
