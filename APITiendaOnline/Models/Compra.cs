namespace APITiendaOnline.Models
{
	public class Compra
	{
        public int Cantidad { get; set; }
        public string Precio { get; set; }
		public string FechaCaducidad { get; set; }
		public int IdProducto { get; set; }
	}
}
