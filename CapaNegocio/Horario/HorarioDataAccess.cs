using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reserva;
using CapaNegocio.Horario.DTO;

namespace CapaNegocio.Horario
{
    public class HorarioDataAccess
    {

        //METODO CREAR HORARIO
        public CreateHorarioResponse CreateHorario(CreateHorarioRequest nuevoHorario)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));



                    context.PA_INSERT_HORARIO(
                        nuevoHorario.Nombre,
                        nuevoHorario.Horario,
                        RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new CreateHorarioResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateHorarioResponse()
                {
                    Mensaje = ex.Message.Trim(),
                    Retcode = -1
                };
            }
        }

        //MÉTODO DE BORRAR HORARIO
        public DeleteHorarioResponse DeleteHorario(DeleteHorarioRequest delHorario)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_DELETE_HORARIO(delHorario.Id_horario, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeleteHorarioResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteHorarioResponse()
                {
                    Mensaje = ex.Message,
                    Retcode = -1
                };
            }

        }

        //METODO LISTAR HORARIOS
        public IEnumerable<HorarioModel> GetHorarioes()
        {
            List<HorarioModel> listaHorarios = null;

            try
            {
                using (var context = new BDReservasEntities())
                {

                    listaHorarios = (from i in context.horarios
                                        select new HorarioModel
                                        {
                                            Id_horario = i.id_horario,
                                            Horario = i.horario.Trim(),
                                            Nombre = i.nombre.Trim(),

                                        }).ToList();

                    if (listaHorarios.Count < 1)
                    {
                        listaHorarios.Add(new HorarioModel
                        {
                            Mensaje = "No existen actividades"
                        });

                    }

                    return listaHorarios;

                }


            }
            catch (Exception ex)
            {
                listaHorarios.Add(new HorarioModel
                {
                    Mensaje = "No se pudo realizar la consulta -- " + ex.Message
                });

                return listaHorarios;

            }
        }

        //METODO ACTUALIZAR HORARIO
        public UpdateHorarioResponse UpdateHorario(UpdateHorarioRequest upHorario)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));


                    context.PA_MODIFICAR_HORARIO(upHorario.Id_horario, upHorario.Nombre, upHorario.Horario, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new UpdateHorarioResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdateHorarioResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

    }
}
