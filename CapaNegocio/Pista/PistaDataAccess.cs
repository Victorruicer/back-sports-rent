using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reserva;
using CapaNegocio.Pista.DTO;

namespace CapaNegocio.Pista
{
    public class PistaDataAccess
    {
        //RECUPERAR PISTAS DISPONIBLES PARA RESERVAR
        public IEnumerable<PistasReservaResponse> pistasParaReserva(PistasReservaRequest datos)
        {
            List<PistasReservaResponse> listaPistas = null;
            try
            {
                using (var context = new BDReservasEntities())
                {
                    listaPistas = (from i in context.V_INSTALACIONES_HORARIOS
                                   where i.actividad == datos.Actividad
                                   select new PistasReservaResponse
                                   {
                                       Pista = i.pista.Trim(),
                                       Horario = i.horario.Trim(),
                                       Instalacion = i.instalacion.Trim(),
                                       Precio_hora = i.precio_hora

                                   }).ToList();

                    //si no se encuentran pistas se devuelve msje informativo
                    if (listaPistas.Count < 1)
                    {
                        listaPistas.Add(new PistasReservaResponse() { Mensaje = "No existen pistas disponibles." });
                    }

                    return listaPistas;

                }

            }
            catch (Exception ex)
            {
                listaPistas.Add(new PistasReservaResponse()
                {
                    Mensaje = "No se pudo realizar la consulta. -- " + ex.Message
                });

                return listaPistas;

            }
        }

        //METODO CREAR PISTA
        public CreatePistaResponse CreatePista(CreatePistaRequest nuevaPista)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter ID = new ObjectParameter("ID", typeof(int));
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));



                    context.PA_INSERT_PISTA(
                        nuevaPista.Nombre,
                        nuevaPista.Id_instalacion,
                        nuevaPista.Operativa,
                        nuevaPista.Id_tarifa,
                        nuevaPista.Id_actividad,
                        ID, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new CreatePistaResponse()
                    {
                        Id = (int)ID.Value,
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreatePistaResponse()
                {
                    Mensaje = ex.Message.Trim()
                };
            }
        }

        //MÉTODO DE BORRAR PISTA
        public DeletePistaResponse DeletePista(DeletePistaRequest delPista)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_DELETE_PISTA(delPista.Id_pista, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeletePistaResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeletePistaResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

        //METODO LISTAR PISTAS
        public IEnumerable<PistaModel> GetPistas()
        {
            List<PistaModel> listaInstalaciones = null;

            try
            {
                using (var context = new BDReservasEntities())
                {

                    listaInstalaciones = (from i in context.V_INSTALACIONES_HORARIOS
                                            select new PistaModel
                                            {
                                                Instalacion = i.instalacion.Trim(),
                                                Horario = i.horario,
                                                Pista = i.pista.Trim(),
                                                Actividad = i.actividad.Trim(),
                                                Tipo_pista = i.tipo_pista.Trim(),
                                                Precio_hora = i.precio_hora,
                                            }).ToList();

                    if (listaInstalaciones.Count < 1)
                    {
                        listaInstalaciones.Add(new PistaModel
                        {
                            Mensaje = "No existen instalaciones"
                        });

                    }

                    return listaInstalaciones;

                }


            }
            catch (Exception ex)
            {
                listaInstalaciones.Add(new PistaModel
                {
                    Mensaje = "No se pudo realizar la consulta -- " + ex.Message
                });

                return listaInstalaciones;

            }
        }

        //METODO ACTUALIZAR PISTA
        public UpdatePistaResponse UpdatePista(UpdatePistaRequest upPista)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));


                    context.PA_MODIFICAR_PISTA(upPista.Nombre, upPista.Id_instalacion, upPista.Operativa, upPista.Id_tarifa, upPista.Id_actividad, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    var consulta = context.pistas.Where(pista => pista.nombre == upPista.Nombre).FirstOrDefault();

                    return new UpdatePistaResponse()
                    {
                        Nombre = consulta.nombre,
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdatePistaResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

    }
}
