using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using CapaDatos.Reserva;
using CapaNegocio.Helpers;
using CapaNegocio.Usuario.DTO;



namespace CapaNegocio.Usuario
{
    public class UsuarioDataAccess
    {

        //MÉTODO DE LOGIN
        public LoginResponse Login(LoginRequest login)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter ID = new ObjectParameter("ID", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_LOGIN(login.Email, login.Password, ID, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    var consulta = context.usuarios.Where(user => user.id_usuario == (int)ID.Value).FirstOrDefault();

                    var imagen = "";

                    if (consulta.imagen != null)
                    {
                       imagen = new ImageConverter().byteTobase64(consulta.imagen);
                    }

                    return new LoginResponse()
                    {
                        Id_Usuario = consulta.id_usuario,
                        Nombre = consulta.nombre.Trim(),
                        Apellido1 = consulta.apellido1.Trim(),
                        Apellido2 = consulta.apellido2.Trim(),
                        Dni = consulta.dni.Trim(),
                        Email = consulta.email.Trim(),
                        Id_Perfil = consulta.id_perfil,
                        Imagen = imagen,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResponse()
                {
                    Mensaje = ex.Message.Trim(), //mensaje de error
                    Id_Perfil = -1 //no añadirá token
                };
            }

        }

        //MÉTODO DE CREAR USUARIO
        public CreateUserResponse CreateUser(CreateUserRequest newUser)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    byte[] imagen = null;
/*
                    if(newUser.Imagen != "")
                    {
                        imagen = new ImageConverter().base64ToByte(newUser.Imagen);
                    }
*/
                    context.PA_INSERT_USUARIO(
                        newUser.Nombre,
                        newUser.Apellido1,
                        newUser.Apellido2,
                        newUser.Dni,
                        newUser.Email,
                        newUser.Password,
                        newUser.Id_Perfil,
                        imagen,
                        RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    var consulta = context.usuarios.Where(dni => dni.dni == newUser.Dni).FirstOrDefault();

                    return new CreateUserResponse()
                    {
                        Nombre = consulta.nombre,
                        Apellido1 = consulta.apellido1,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateUserResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }

        //MÉTODO REGISTRO USUARIO
        public RegistroResponse Registro(RegistroRequest registro)
        {
            try
            {

                using (var context = new BDReservasEntities())
                {

                    //la imagen del usuario se añadirá desde su perfil, no al registrarse
                    byte[] imagen = (registro.Imagen != "") ? new ImageConverter().base64ToByte(registro.Imagen) : null;
                    //byte[] imagen = null;

                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_INSERT_USUARIO(
                        registro.Nombre,
                        registro.Apellido1,
                        registro.Apellido2,
                        registro.Dni,
                        registro.Email,
                        registro.Password,
                        registro.Id_perfil,
                        imagen,
                        RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    var consulta = context.usuarios.Where(dni => dni.dni == registro.Dni).FirstOrDefault();

                    return new RegistroResponse()
                    {
                        Nombre = consulta.nombre.Trim(),
                        Apellido1 = consulta.apellido1.Trim(),
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };


                }

            }
            catch (Exception ex)
            {
                return new RegistroResponse()
                {
                    Mensaje = ex.Message.Trim()
                };
            }

        }

        
        //MÉTODO DE BORRAR USUARIO
        public DeleteUserResponse DeleteUser(DeleteUserRequest delUser)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    var consulta = context.usuarios.Where(user => user.id_usuario == delUser.Id_Usuario).FirstOrDefault();

                    context.PA_DELETE_USUARIO(delUser.Id_Usuario, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString().Trim());
                    }

                    return new DeleteUserResponse()
                    {
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString().Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeleteUserResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }
        
        //MÉTODO DE ACTUALIZAR USUARIO
        public UpdateUserResponse UpdateUser(UpdateUserRequest upUser)
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    ObjectParameter RETCODE = new ObjectParameter("RETCODE", typeof(int));
                    ObjectParameter MENSAJE = new ObjectParameter("MENSAJE", typeof(string));

                    context.PA_MODIFICAR_USUARIO(upUser.Id_Usuario, upUser.Nombre, upUser.Apellido1, upUser.Apellido2, upUser.Id_Perfil, RETCODE, MENSAJE);

                    if ((int)RETCODE.Value < 0)
                    {
                        throw new Exception("Error no controlado");
                    }

                    if ((int)RETCODE.Value > 0)
                    {
                        throw new Exception(MENSAJE.Value.ToString());
                    }

                    var consulta = context.usuarios.Where(user => user.id_usuario == upUser.Id_Usuario).FirstOrDefault();

                    return new UpdateUserResponse()
                    {
                        Email = consulta.email,
                        Retcode = (int)RETCODE.Value,
                        Mensaje = MENSAJE.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UpdateUserResponse()
                {
                    Mensaje = ex.Message
                };
            }

        }
        
        //METODO CAMBIO PASSWORD


        //MÉTODO DE LISTADO DE TODOS LOS USUARIOS
        public IEnumerable<User> GetUsers()
        {
            try
            {
                using (var context = new BDReservasEntities())
                {
                    List<User> listUsuarios = (from V_USUARIOS_PERFILES in context.V_USUARIOS_PERFILES
                                               select new User
                                               {
                                                   Id_Usuario = V_USUARIOS_PERFILES.id_usuario,
                                                   Nombre = V_USUARIOS_PERFILES.nombre,
                                                   Apellido1 = V_USUARIOS_PERFILES.apellido1,
                                                   Apellido2 = V_USUARIOS_PERFILES.apellido2,
                                                   Perfil = V_USUARIOS_PERFILES.perfil,
                                                   Email = V_USUARIOS_PERFILES.email,
                                                   Dni = V_USUARIOS_PERFILES.dni
                                                  

                                               }).ToList<User>();
                    return listUsuarios;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
