using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APITiendaOnline.Models;

namespace APITiendaOnline.Data
{
    public class APITiendaOnlineContext : DbContext
    {
        public APITiendaOnlineContext (DbContextOptions<APITiendaOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<APITiendaOnline.Models.Compra> Compra { get; set; } = default!;
    }
}
