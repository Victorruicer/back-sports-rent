using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reserva;
using CapaNegocio.Pista.DTO;
using CapaNegocio.Reserva.DTO;

namespace CapaNegocio.Pista
{
    public class PistaDataAccess
    {
        //RECUPERAR PISTAS DISPONIBLES PARA RESERVA
        //recibimos deporte y fecha en datos
        //devolvemos array de pistas con las horas libres y reservadas para fecha y deporte recibidos
        public IEnumerable<PistasReservaResponse> pistasParaReserva(PistasReservaRequest datos)
        {
            List<PistasReservaResponse> pistasConReserva = new List<PistasReservaResponse>();
            List<PistasReservaResponse> listaPistas = null;//lista de pistas disponibles para el deporte
            List<PistasReservaResponse> response = new List<PistasReservaResponse>();
            try
            {
                //recuperamos listado pistas
                using (var context = new BDReservasEntities())
                {
                    listaPistas = (from i in context.V_INSTALACIONES_HORARIOS
                                   where i.actividad == datos.Actividad
                                   where i.pista_operativa == true
                                   where i.instalación_operativa == true
                                   select new PistasReservaResponse
                                   {
                                       Pista = i.pista.Trim(),
                                       Id_pista = i.id_pista,
                                       Horario = i.horario.Trim(),
                                       Instalacion = i.instalacion.Trim(),
                                       Precio_hora = i.precio_hora,
                                       Fecha = datos.Fecha.Trim()

                                   }).ToList();

                    //si no se encuentran pistas se devuelve msje informativo
                    if (listaPistas.Count < 1)
                    {
                        pistasConReserva.Add(new PistasReservaResponse() { Mensaje = "No existen pistas disponibles " });
                    }
                    else
                    {
                        //recuperamos horas reservadas/libres para cada pista el dia indicado
                        foreach(var p in listaPistas)
                        {
                            List<PistasReservaResponse> tmp  = (from i in context.V_RESERVAS_PISTAS
                                                                where i.pista == p.Pista
                                                                where i.fecha == datos.Fecha
                                                                where i.estado != "cancelada"
                                                                select new PistasReservaResponse
                                                                {
                                                                    Pista = i.pista.Trim(),
                                                                    Id_pista = i.id_pista,
                                                                    H_ini = i.h_ini.Trim(),
                                                                    H_fin = i.h_fin.Trim(),
                                                                    Horas = (decimal)i.horas,
                                                                    Horario = p.Horario.Trim(),
                                                                    Instalacion = p.Instalacion.Trim(),
                                                                    Precio_hora = p.Precio_hora,
                                                                    Fecha = datos.Fecha,

                                                                }).ToList();

                            //si no hay reservas para la pista
                            if(tmp.Count < 1)
                            {
                                List<PistasReservaResponse> vacia = new List<PistasReservaResponse>{ p };
                                pistasConReserva.AddRange(vacia);
                            }
                            else
                            {
                                pistasConReserva.AddRange(tmp);
                            }


                        }
                        string[] ph = new string[13];
                        string nomPista = "";
                        PistasReservaResponse pisres = null;
                        //recorremos las pistas con reserva encontradas
                        for (var x = 0; x <= pistasConReserva.Count(); x++)
                        {
                            if (x != pistasConReserva.Count())
                            {
                                if (pistasConReserva[x].Pista != nomPista)//es pista distinta
                                {
                                    if (pisres != null)
                                    {
                                        pisres.H_ini = null;
                                        pisres.H_fin = null;
                                        pisres.Horas = 0;
                                        response.Add(pisres);//guardamos pista con sus reservas
                                    }
                                    ph = new string[13];
                                    pisres = null;
                                    nomPista = pistasConReserva[x].Pista;
                                    pisres = pistasConReserva[x];

                                    ph = this.checkHorasReserva(pistasConReserva[x], ph);
                                    pisres.LibresReservadas = ph;
                                }
                                else
                                {
                                    ph = this.checkHorasReserva(pistasConReserva[x], ph);
                                    pisres.LibresReservadas = ph;
                                }
                            }
                            else
                            {
                                pisres.H_ini = null;
                                pisres.H_fin = null;
                                pisres.Horas = 0;
                                response.Add(pisres);//guardamos pista con sus reservas
                            }

                        }
                    }

                    return response;

                }

            }
            catch (Exception ex)
            {
                response.Add(new PistasReservaResponse()
                {
                    Mensaje = "No se pudo realizar la consulta. -- " + ex.Message
                });

                return pistasConReserva;

            }

        }

        //METODO CREAR PISTA
        public CreatePistaResponse CreatePista(CreatePistaRequest nuevaPista)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));



                    context.PA_INSERT_PISTA(
                        nuevaPista.Nombre,
                        nuevaPista.Id_instalacion,
                        nuevaPista.Operativa,
                        nuevaPista.Id_tarifa,
                        nuevaPista.Id_actividad,
                        RETCODE, MENSAJE);

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
            List<PistaModel> listaPistas = null;

            try
            {
                using (var context = new BDReservasEntities())
                {

                    listaPistas = (from i in context.V_INSTALACIONES_HORARIOS
                                   where i.id_actividad != 23  
                                            select new PistaModel
                                            {
                                                Instalacion = i.instalacion.Trim(),
                                                Horario = i.horario,
                                                Nombre = i.pista.Trim(),
                                                Actividad = i.actividad.Trim(),
                                                Tipo_pista = i.tipo_pista.Trim(),
                                                Precio_hora = i.precio_hora,
                                                Id_actividad = i.id_actividad,
                                                Id_instalacion = i.id_instalacion,
                                                Id_pista = i.id_pista,
                                                Id_tarifa = i.id_tarifa,
                                                Tarifa = i.tarifa,
                                                Operativa = (bool)i.pista_operativa

                                            }).Distinct().ToList();

                    if (listaPistas.Count < 1)
                    {
                        listaPistas.Add(new PistaModel
                        {
                            Mensaje = "No existen instalaciones"
                        });

                    }

                    return listaPistas;

                }


            }
            catch (Exception ex)
            {
                listaPistas.Add(new PistaModel
                {
                    Mensaje = "No se pudo realizar la consulta -- " + ex.Message
                });

                return listaPistas;

            }
        }
 /*
        //METODO LISTAR PISTAS
        public IEnumerable<PistaModel> GetPistas()
        {
            List<PistaModel> listaPistas = null;

            try
            {
                using (var context = new BDReservasEntities())
                {

                    listaPistas = (from i in context.pistas
                                   select new PistaModel
                                   {
                                       Nombre = i.nombre.Trim(),
                                       Id_actividad = (int)i.id_actividad,
                                       Id_instalacion = i.id_instalacion,
                                       Id_pista = i.id_pista,
                                       Id_tarifa = (int)i.id_tarifa,
                                       Operativa = (bool)i.operativa

                                   }).ToList();

                    if (listaPistas.Count < 1)
                    {
                        listaPistas.Add(new PistaModel
                        {
                            Mensaje = "No existen instalaciones"
                        });

                    }

                    return listaPistas;

                }


            }
            catch (Exception ex)
            {
                listaPistas.Add(new PistaModel
                {
                    Mensaje = "No se pudo realizar la consulta -- " + ex.Message
                });

                return listaPistas;

            }
        }*/

        //METODO ACTUALIZAR PISTA
        public UpdatePistaResponse UpdatePista(UpdatePistaRequest upPista)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));


                    context.PA_MODIFICAR_PISTA(upPista.Id_pista, upPista.Nombre, upPista.Id_instalacion, upPista.Operativa, upPista.Id_tarifa, upPista.Id_actividad, RETCODE, MENSAJE);

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
                        Nombre = consulta.nombre.Trim(),
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

        private string[] checkHorasReserva(PistasReservaResponse pistaReservada, string[] ph)
        {
            int horaini;
            //para pistas sin reservas
            if (pistaReservada.H_ini == null && pistaReservada.H_fin == null)
            {
                //ponemos una hora alta para que el bucle siempre ponga libres las horas
                horaini = 0;
            }
            else
            {
                //si la hora y la reserva coinciden se guarda
                horaini = short.Parse(pistaReservada.H_ini.Substring(0, 2));
            }

            //miramos que horas tienen reservadas
            for (var hora = 8; hora < 20; hora++)
            {

                if (hora == horaini)
                {
                    ph[hora - 8] = "reservada";
                    ph[hora - 7] = (pistaReservada.Horas > 1 || (hora -7) == 12) ? "reservada" : "libre";
                    
                }
                else
                {
                    ph[hora - 8] = (ph[hora -8] != "reservada" || ph[hora - 8] == null) ? "libre" : "reservada";
                }

            }
            return ph;
        }
    }
}
