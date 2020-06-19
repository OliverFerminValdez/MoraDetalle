using Microsoft.EntityFrameworkCore;
using MoraDetalleApp.DAL;
using MoraDetalleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoraDetalleApp.BLL
{
    public class PrestamosBLL
    {
            public static bool Guardar(Prestamos prestamo)
            {
                if (!Existe(prestamo.PrestamoId))
                    return Insertar(prestamo);
                else
                    return Modificar(prestamo);
            }

            private static bool Insertar(Prestamos prestamo)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                 
                    contexto.Prestamos.Add(prestamo);
                    paso = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return paso;
            }

            public static bool Modificar(Prestamos prestamo)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Database.ExecuteSqlRaw($"Delete FROM PrestamosDetalle Where prestamoId = {prestamo.PrestamoId}");

                    foreach (var item in prestamo.MoraDetalles)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }

                    contexto.Entry(prestamo).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return paso;
            }
            public static bool Eliminar(int id)
            {
                bool paso = false;
                Contexto contexto = new Contexto();
                try
                {
                    var prestamo = contexto.Prestamos.Find(id);

                    if (prestamo != null)
                    {
                        contexto.Prestamos.Remove(prestamo);
                        paso = contexto.SaveChanges() > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return paso;
            }
            public static Prestamos Buscar(int id)
            {
                Contexto contexto = new Contexto();
                Prestamos prestamo;

                try
                {
                    prestamo = contexto.Prestamos
                        .Where(e => e.PrestamoId == id)
                        .Include(e => e.MoraDetalles)
                        .FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return prestamo;
            }

            public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
            {
                List<Prestamos> lista = new List<Prestamos>();
                Contexto contexto = new Contexto();
                try
                {
                    lista = contexto.Prestamos.Where(criterio).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return lista;
            }

            public static bool Existe(int id)
            {
                Contexto contexto = new Contexto();
                bool encontrado = false;

                try
                {
                    encontrado = contexto.Prestamos.Any(e => e.PrestamoId == id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }

                return encontrado;
            }

            public static List<Prestamos> Getprestamo()
            {
                List<Prestamos> lista = new List<Prestamos>();
                Contexto contexto = new Contexto();
                try
                {
                    lista = contexto.Prestamos.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return lista;
            }
        }
    }


