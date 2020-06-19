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
            /// <summary>
            /// Permite insertar o modificar una entidad en la base de datos
            /// </summary>
            /// <param name="prestamo">La entidad que se desea guardar</param> 
            public static bool Guardar(Prestamos prestamo)
            {
                if (!Existe(prestamo.PrestamoId))//si no existe insertamos
                    return Insertar(prestamo);
                else
                    return Modificar(prestamo);
            }

            /// <summary>
            /// Permite insertar una entidad en la base de datos
            /// </summary>
            /// <param name="prestamo">La entidad que se desea guardar</param>
            private static bool Insertar(Prestamos prestamo)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    //Agregar la entidad que se desea insertar al contexto
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

            /// <summary>
            /// Permite modificar una entidad en la base de datos
            /// </summary>
            /// <param name="prestamo">La entidad que se desea modificar</param> 
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

                    //marcar la entidad como modificada para que el contexto sepa como proceder
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

            /// <summary>
            /// Permite eliminar una entidad de la base de datos
            /// </summary>
            /// <param name="id">El Id de la entidad que se desea eliminar</param> 
            public static bool Eliminar(int id)
            {
                bool paso = false;
                Contexto contexto = new Contexto();
                try
                {
                    //buscar la entidad que se desea eliminar
                    var prestamo = contexto.Prestamos.Find(id);

                    if (prestamo != null)
                    {
                        contexto.Prestamos.Remove(prestamo);//remover la entidad
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

            /// <summary>
            /// Permite buscar una entidad en la base de datos
            /// </summary>
            /// <param name="id">El Id de la entidad que se desea buscar</param> 
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

            /// <summary>
            /// Permite obtener una lista filtrada por un criterio de busqueda
            /// </summary>
            /// <param name="criterio">La expresión que define el criterio de busqueda</param>
            /// <returns></returns>
            public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
            {
                List<Prestamos> lista = new List<Prestamos>();
                Contexto contexto = new Contexto();
                try
                {
                    //obtener la lista y filtrarla según el criterio recibido por parametro.
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


