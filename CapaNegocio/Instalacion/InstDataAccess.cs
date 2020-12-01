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
                        nuevaInstalacion.Nombre,
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
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateInstResponse()
                {
                    Mensaje = ex.Message.Trim()
                };
            }
        }

        //MÉTODO DE BORRAR INSTALACION
        /*
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
        */
    }
}
