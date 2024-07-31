using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaOnline.Models
{
	public class Productos
	{
        public string Id { get; set; }
        public string Producto { get; set; }
        public string Precio { get; set; }
        public string FechaCaducidad { get; set; }
    }
}
