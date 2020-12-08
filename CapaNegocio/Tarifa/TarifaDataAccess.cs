using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reserva;
using CapaNegocio.Tarifa.DTO;

namespace CapaNegocio.Tarifa
{
    public class TarifaDataAccess
    {
        /*
        //METODO CREAR TARIFA
        public CreateTarifaResponse CreateTarifa(CreateTarifaRequest nuevaTarifa)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));


                    context.PA_INSERT_TARIFA(
                        nuevaTarifa.Tarifa,
                        nuevaTarifa.Valor,
                        RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    return new CreateTarifaResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateTarifaResponse()
                {
                    Mensaje = ex.Message.Trim(),
                    Retcode = -1
                };
            }
        }

        //MÉTODO DE BORRAR TARIFA
        public DeleteTarifaResponse DeleteTarifa(DeleteTarifaRequest delTarifa)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_DELETE_TARIFA(delTarifa.Id_tarifa, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeleteTarifaResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteTarifaResponse()
                {
                    Mensaje = ex.Message,
                    Retcode = -1
                };
            }

        }

        //METODO LISTAR TARIFAS
        public IEnumerable<TarifaModel> GetTarifas()
        {
            try
            {
                using (var context = new BDReservasEntities())
                {

                    List<TarifaModel> listaTarifas = (from TARIFAS in context.tarifas
                                                          select new TarifaModel
                                                          {
                                                              Tarifa = TARIFAS.tarifa.Trim(),
                                                              Valor = TARIFAS.valor,
                                                              Id_tarifa = TARIFAS.id_tarifa

                                                          }).ToList<TarifaModel>();

                    if (listaTarifas.Count < 1)
                    {
                        listaTarifas.Add(new TarifaModel
                        {
                            Mensaje = "No existen tarifas"
                        });

                    }

                    return listaTarifas;

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //METODO ACTUALIZAR TARIFA
        public UpdateTarifaResponse UpdateTarifa(UpdateTarifaRequest upTarifa)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));


                    context.PA_MODIFICAR_TARIFA(upTarifa.Id_Tarifa ,upTarifa.Tarifa, upTarifa.Valor, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

    
                    return new UpdateTarifaResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdateTarifaResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

*/
    }
}
