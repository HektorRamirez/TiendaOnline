using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITiendaOnline.Data;
using APITiendaOnline.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APITiendaOnline.Controllers
{
    [Route("api/agregarCompra")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
		private readonly APITiendaOnlineContext _context;
		private readonly IConfiguration _configuration;

		public ComprasController(APITiendaOnlineContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}
		[HttpPost]
		public async Task<IActionResult> EnviarCompra([FromBody] Compra compra)
		{
			var connectionString = _configuration.GetConnectionString("APITiendaOnlineContext");
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand("SP_AgregarAlCarrito", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Cantidad", compra.Cantidad);
					cmd.Parameters.AddWithValue("@Precio", compra.Precio);
					cmd.Parameters.AddWithValue("@FechaCaducidad", compra.FechaCaducidad);
					cmd.Parameters.AddWithValue("@IdProducto", compra.IdProducto);

					conn.Open();
					await cmd.ExecuteNonQueryAsync();
					conn.Close();
				}
			}

			return Ok(new { message = "Compra enviada correctamente" });
		}
}

}
