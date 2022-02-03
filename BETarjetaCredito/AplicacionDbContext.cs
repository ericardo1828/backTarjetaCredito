using BETarjetaCredito.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETarjetaCredito
{
    public class AplicacionDbContext: DbContext
    {
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options): base(options)
        {

        }

    }
}
