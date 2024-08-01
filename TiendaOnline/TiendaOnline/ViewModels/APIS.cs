using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TiendaOnline.Models;

namespace TiendaOnline.ViewModels
{
	public class APIS
	{
		#region Variables
		
        private readonly HttpClient _httpClient;

		#endregion

		#region Constructor
		public APIS()
        {
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost/api/agregarCompra") };
		}
		#endregion

		#region Funciones
		public async Task<bool> EnviarCompras(DetalleCompra compra)
		{
			try
			{
				var json = JsonConvert.SerializeObject(compra);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync("api/agregarCompra", content);

				return response.IsSuccessStatusCode;
			}
			catch (Exception ex) 
			{
				Console.WriteLine($"Error al enviar la compra: {ex.Message}");
				return false;
			}

			
		}
        #endregion

        #region Variables
        #endregion
    }
}
