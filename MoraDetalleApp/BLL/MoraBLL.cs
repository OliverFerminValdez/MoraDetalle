using MoraDetalleApp.DAL;
using MoraDetalleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoraDetalleApp.BLL
{
    public class MoraBLL
    {
        public static List<Moras> GetMoras()
        {
            Contexto db = new Contexto();
            List<Moras> lista = new List<Moras>();

            try
            {
                lista = db.Moras.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
        public static Moras Buscar(int id)
        {
            Contexto db = new Contexto();
            Moras mora = new Moras();

            try
            {
                mora = db.Moras.Find(id);
            }
            catch (Exception)
            {

                throw;
            }finally
            {
                db.Dispose();
            }
            return mora;
        }
    }
}
