using System;
using System.Collections.Generic;
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
                using(var context = new BDReservasEntities())
                {
                    listaPistas = (from i in context.V_INSTALACIONES_HORARIOS
                                                               where i.actividad == datos.Actividad
                                                               select new PistasReservaResponse
                                                               {
                                                                   Pista = i.pista.Trim(),
                                                                   Horario = i.horario.Trim(),
                                                                   Instalacion = i.instalacion.Trim(),
                                                                   Precio_hora = i.precio_hora

                                                               }).ToList<PistasReservaResponse>();
                
                    //si no se encuentran pistas se devuelve msje informativo
                    if(listaPistas.Count < 1)
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
    }
}
