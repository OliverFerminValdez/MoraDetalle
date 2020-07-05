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
            dbContext.UseSqlite(@"Data Source = DATA\MoraDetalle.db");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Moras>().HasData(new Moras
            {
                MoraId = 1,
                Fecha = DateTime.Now,
                Valor = 5000
            });
            model.Entity<Moras>().HasData(new Moras
            {
                MoraId = 2,
                Fecha = new DateTime(2020,04,27),
                Valor = 5000
            });
            model.Entity<Moras>().HasData(new Moras
            {
                MoraId = 3,
                Fecha = new DateTime(2020,05,27),
                Valor = 5000
            });
        }
    }
}
