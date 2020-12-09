using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reserva;
using CapaNegocio.Actividad.DTO;

namespace CapaNegocio.Actividad
{
    public class ActividadDataAccess
    {

        //METODO CREAR ACTIVIDAD
        public CreateActividadResponse CreateActividad(CreateActividadRequest nuevaActividad)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));



                    context.PA_INSERT_ACTIVIDAD(
                        nuevaActividad.Actividad,
                        nuevaActividad.Tipo_pista,
                        RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new CreateActividadResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateActividadResponse()
                {
                    Mensaje = ex.Message.Trim(),
                    Retcode = -1
                };
            }
        }

        //MÉTODO DE BORRAR ACTIVIDAD
        public DeleteActividadResponse DeleteActividad(DeleteActividadRequest delActividad)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_DELETE_ACTIVIDAD(delActividad.Id_actividad, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeleteActividadResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteActividadResponse()
                {
                    Mensaje = ex.Message,
                    Retcode = -1
                };
            }

        }

        //METODO LISTAR ACTIVIDADES
        public IEnumerable<ActividadModel> GetActividades()
        {
            List<ActividadModel> listaActividades = null;

            try
            {
                using (var context = new BDReservasEntities())
                {

                    listaActividades = (from i in context.actividades
                                          select new ActividadModel
                                          {
                                              Id_actividad = i.id_actividad,
                                              Actividad = i.actividad,
                                              Tipo_pista = i.tipo_pista.Trim(),

                                          }).ToList();

                    if (listaActividades.Count < 1)
                    {
                        listaActividades.Add(new ActividadModel
                        {
                            Mensaje = "No existen actividades"
                        });

                    }

                    return listaActividades;

                }


            }
            catch (Exception ex)
            {
                listaActividades.Add(new ActividadModel
                {
                    Mensaje = "No se pudo realizar la consulta -- " + ex.Message
                });

                return listaActividades;

            }
        }

        //METODO ACTUALIZAR ACTIVIDAD
        public UpdateActividadResponse UpdateActividad(UpdateActividadRequest upActividad)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));


                    context.PA_MODIFICAR_ACTIVIDAD(upActividad.Id_actividad, upActividad.Actividad, upActividad.Tipo_pista, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new UpdateActividadResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdateActividadResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

    }
}
