using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reserva;
using CapaNegocio.Helpers;
using CapaNegocio.Instalacion.DTO;

namespace CapaNegocio.Instalacion
{
    public class InstDataAccess
    {
        //METODO CREAR INSTALACION
        public CreateInstResponse CreateInst(CreateInstRequest nuevaInstalacion)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter ID = new ObjectParameter("ID", typeof(int));
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    byte[] imagen = null;

                    if (nuevaInstalacion.Imagen != null)
                    {
                        imagen = new ImageConverter().base64ToByte(nuevaInstalacion.Imagen);
                    }
                    else
                    {
                        nuevaInstalacion.Imagen = null;
                    }

                    context.PA_INSERT_INSTALACION(
                        nuevaInstalacion.Instalacion,
                        nuevaInstalacion.Direccion,
                        nuevaInstalacion.Operativa,
                        nuevaInstalacion.Id_Horario,
                        imagen,
                        ID, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new CreateInstResponse()
                    {
                        Id_Instalacion = (int)ID.Value,
                        Mensaje = MENSAJE.Value.ToString(),
                        Retcode = (int)RETCODE.Value
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateInstResponse()
                {
                    Mensaje = ex.Message.Trim(),
                    Retcode = -1
                };
            }
        }

        //MÉTODO DE BORRAR INSTALACION
        public DeleteInstResponse DeleteInst(DeleteInstRequest delInstalacion)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_DELETE_INSTALACION(delInstalacion.Id_Instalacion, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeleteInstResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteInstResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

        //METODO LISTAR INSTALACIONES
        public IEnumerable<InstModel> GetInsts()
        {
            try
            {
                using (var context = new BDReservasEntities())
                {

                    List<InstModel> listaInstalaciones = (from i in context.instalaciones
                                                          select new InstModel
                                                          {
                                                              Nombre = i.nombre.Trim(),
                                                              Id_instalacion = i.id_instalacion,
                                                              Id_horario = i.id_horario,
                                                              Direccion = i.direccion.Trim(),
                                                              Imgtmp = i.imagen,
                                                              Operativa = i.operativa
                                                          }).ToList<InstModel>();

                    if (listaInstalaciones.Count < 1)
                    {
                        listaInstalaciones.Add(new InstModel
                        {
                            Mensaje = "No existen instalaciones"
                        });

                    }
                    else
                    {   //parche para convertir cada imagen del array de instalaciones
                        foreach (InstModel instalacion in listaInstalaciones)
                        {
                            instalacion.Imagen = (instalacion.Imgtmp != null) ? new ImageConverter().byteTobase64(instalacion.Imgtmp) : null;
                            instalacion.Imgtmp = null;
                        }
                    }

                    return listaInstalaciones;

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<InstModel> GetInstsVista()
        {
            try
            {
                using (var context = new BDReservasEntities())
                {

                    List<InstModel> listaInstalaciones = (from i in context.V_INSTALACIONES_HORARIOS
                                                          select new InstModel
                                                          {
                                                              Instalacion = i.instalacion.Trim(),
                                                              Direccion = i.direccion.Trim(),
                                                              Horario = i.horario.Trim(),
                                                              Id_instalacion = i.id_instalacion,
                                                              Operativa = i.instalación_operativa,
                                                              Tipo_horario = i.tipo_horario.Trim()

                                                          }).Distinct().ToList<InstModel>();

                    if (listaInstalaciones.Count < 1)
                    {
                        listaInstalaciones.Add(new InstModel
                        {
                            Mensaje = "No existen instalaciones"
                        });

                    }
                    else
                    {   //parche para convertir cada imagen del array de instalaciones
                        foreach (InstModel instalacion in listaInstalaciones)
                        {
                            instalacion.Imagen = (instalacion.Imgtmp != null) ? new ImageConverter().byteTobase64(instalacion.Imgtmp) : null;
                            instalacion.Imgtmp = null;
                        }
                    }

                    return listaInstalaciones;

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO ACTUALIZAR INSTALACION
        public UpdateInstResponse UpdateInst(UpdateInstRequest upInst)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    byte[] imagen = null;

                    if (upInst.Imagen != null)
                    {
                        imagen = new ImageConverter().base64ToByte(upInst.Imagen);
                    }
                    else
                    {
                        upInst.Imagen = null;
                    }


                    context.PA_MODIFICAR_INSTALACION(upInst.Id_instalacion, upInst.Instalacion, upInst.Direccion, upInst.Operativa, upInst.Id_horario, imagen, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    var consulta = context.instalaciones.Where(user => user.nombre == upInst.Instalacion).FirstOrDefault();

                    return new UpdateInstResponse()
                    {
                        Nombre = consulta.nombre,
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdateInstResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

        //    public InstModel GetInstalacion(int id)
        //    {
        //        try
        //        {
        //            using (var context = new BDReservasEntities())
        //            {

        //                InstModel instalacion = (from i in context.instalaciones
        //                                                   where i.id_instalacion == id
        //                                                   select new InstModel
        //                                                   {
        //                                                       Nombre = i.nombre.Trim(),
        //                                                       Id_instalacion = (int)i.id_instalacion,
        //                                                       Id_horario = (int)i.id_horario,
        //                                                       Direccion = i.direccion.Trim(),
        //                                                       Operativa = (bool)i.operativa,
        //                                                       ImgTemp = i.imagen
        //                                                   }).FirstOrDefault();

        //                if (instalacion == null)
        //                {
        //                    return new InstalacionResponse
        //                    {
        //                        Mensaje = "No existe la instalacion solicitada"
        //                    };

        //                }
        //                else
        //                {
        //                    instalacion.Imagen = (instalacion.ImgTemp != null) ? new ImageConverter().byteTobase64(instalacion.ImgTemp) : null;
        //                    instalacion.ImgTemp = null;
        //                }

        //                return instalacion;

        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //}
    }

}
