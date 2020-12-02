using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using CapaDatos.Reserva;
using CapaNegocio.Reserva.DTO;

namespace CapaNegocio.Reserva
{
    public class ReservaDataAccess
    {
        //METODO CREAR RESERVA
        public CreateReservaResponse CreateReserva(CreateReservaRequest nuevaReserva)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter ID_RESERVA = new ObjectParameter("ID_RESERVA", typeof(int));
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    //var cultureInfo = new CultureInfo("es-ES");

                    //CAMBIO DE STRING A FORMATO FECHA
                    /*
                    var fecha = DateTime.Parse(nuevaReserva.Fecha, cultureInfo);
                    var h_ini = TimeSpan.ParseExact(nuevaReserva.H_ini, "HH:mm:ss", cultureInfo);
                    var h_fin = TimeSpan.ParseExact(nuevaReserva.H_fin, "HH:mm:ss", cultureInfo);
                    var createdAt = DateTime.ParseExact(nuevaReserva.Created_at, "MM/dd/yyyy HH:mm:ss", cultureInfo);
                    var updatedAt = DateTime.Parse(nuevaReserva.Updated_at, cultureInfo);
                    */

                    context.PA_INSERT_RESERVA(
                        nuevaReserva.Fecha,
                        nuevaReserva.H_ini,
                        nuevaReserva.H_fin,
                        nuevaReserva.Id_Pista,
                        nuevaReserva.Id_Usuario,
                        nuevaReserva.Created_at,
                        nuevaReserva.Updated_at,
                        nuevaReserva.Id_Estado,
                        nuevaReserva.Precio,
                        nuevaReserva.Horas,
                        ID_RESERVA, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                     return new CreateReservaResponse()
                    {
                        Id_Reserva = (int)ID_RESERVA.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateReservaResponse()
                {
                    Mensaje = ex.Message.Trim()
                };
            }
        }

        //METODO LISTAR RESERVAS
        public IEnumerable<ReservaModel> GetReservas()
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    List<ReservaModel> listReservas = (from V_RESERVAS_PISTAS in context.V_RESERVAS_PISTAS
                                                       select new ReservaModel
                                                       {
                                                           Fecha = V_RESERVAS_PISTAS.fecha.Trim(),
                                                           H_ini = V_RESERVAS_PISTAS.h_ini.Trim(),
                                                           H_fin = V_RESERVAS_PISTAS.h_fin.Trim(),
                                                           Id_Reserva = V_RESERVAS_PISTAS.id_reserva,
                                                           Pista = V_RESERVAS_PISTAS.pista.Trim(),
                                                           Email = V_RESERVAS_PISTAS.email.Trim()

                                                       }).ToList<ReservaModel>();
                    return listReservas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //METODO ELIMINAR RESERVA
        public DeleteReservaResponse DeleteReserva(DeleteReservaRequest delReserva)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_DELETE_RESERVA(delReserva.Id_Reserva, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeleteReservaResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteReservaResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }
        
        /*
        //HISTORICO RESERVAS
        public IEnumerable<ReservaPistaModel> HistoricoReservas(HistoricoReservasRequest datos)
        {
            using(var context = new BDReservasEntities())
            {
                try
                {
                    var sql = "SELECT * FROM V_RESERVAS_PISTAS";
                    List<ReservaPistaModel> reservas = null;

                    //PETICION USUARIO
                    if (datos.Email != "todos")
                    {
                        reservas = (from i in context.V_RESERVAS_PISTAS
                                    where i.email == datos.Email
                                    and )
                    }
                    else//PETICION ADMIN
                    {
                        
                    }

                    

                }
                catch(Exception)
                {

                }
            }
        }*/
    }
}
