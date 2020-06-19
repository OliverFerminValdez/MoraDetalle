using Microsoft.EntityFrameworkCore;
using MoraDetalleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MoraDetalleApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Moras> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlite(@"Data Source = C:\Users\olive\Datos de proyectos\MoraDetalle.db");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            
        }
    }
}
