using System;
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
        public CreateReservaResponse CreateReserva(CreateReservaRequest nuevaReserva)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter ID_RESERVA = new ObjectParameter("ID_RESERVA", typeof(int));
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    var cultureInfo = new CultureInfo("es-ES");

                    //CAMBIO DE STRING A FORMATO FECHA
                    var fecha = DateTime.Parse(nuevaReserva.Fecha, cultureInfo);
                    var h_ini = TimeSpan.ParseExact(nuevaReserva.H_ini, "HH:mm:ss", cultureInfo);
                    var h_fin = TimeSpan.ParseExact(nuevaReserva.H_fin, "HH:mm:ss", cultureInfo);
                    var createdAt = DateTime.ParseExact(nuevaReserva.Created_at, "MM/dd/yyyy HH:mm:ss", cultureInfo);
                    var updatedAt = DateTime.Parse(nuevaReserva.Updated_at, cultureInfo);


                    context.PA_INSERT_RESERVA(
                        fecha,
                        h_ini,
                        h_fin,
                        nuevaReserva.Id_Pista,
                        nuevaReserva.Id_Usuario,
                        createdAt,
                        updatedAt,
                        nuevaReserva.Id_Estado,
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
    }
}
