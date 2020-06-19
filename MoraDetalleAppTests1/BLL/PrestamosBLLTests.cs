using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoraDetalleApp.BLL;
using MoraDetalleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoraDetalleApp.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Prestamos p = new Prestamos();
            p.Persona = "Andres";
            p.Monto = 4000;
            p.Fecha = DateTime.Now;
            p.Balance = 4000;

            bool guardo = PrestamosBLL.Guardar(p);
            Assert.IsTrue(guardo);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Prestamos encontrado = PrestamosBLL.Buscar(1);

            encontrado.Monto = 500;
            encontrado.MoraDetalles = new List<MoraDetalle>();
            bool Modificado = PrestamosBLL.Modificar(encontrado);
            Assert.IsTrue(Modificado);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool eliminado = PrestamosBLL.Eliminar(2);

            Assert.IsTrue(eliminado);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamos encontrado = PrestamosBLL.Buscar(1);
            Assert.IsNotNull(encontrado);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Prestamos> lista = PrestamosBLL.GetList(p=>true);

            Assert.IsNotNull(lista);
        }

    }
}