﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos.Reserva
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BDReservasEntities : DbContext
    {
        public BDReservasEntities()
            : base("name=BDReservasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<estados> estados { get; set; }
        public virtual DbSet<horarios> horarios { get; set; }
        public virtual DbSet<instalaciones> instalaciones { get; set; }
        public virtual DbSet<perfiles> perfiles { get; set; }
        public virtual DbSet<pistas> pistas { get; set; }
        public virtual DbSet<reservas> reservas { get; set; }
        public virtual DbSet<tarifas> tarifas { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<V_USUARIOS_PERFILES> V_USUARIOS_PERFILES { get; set; }
        public virtual DbSet<V_RESERVAS_PISTAS> V_RESERVAS_PISTAS { get; set; }
        public virtual DbSet<actividades> actividades { get; set; }
        public virtual DbSet<V_INSTALACIONES_HORARIOS> V_INSTALACIONES_HORARIOS { get; set; }
    
        public virtual int PA_DELETE_USUARIO(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_USUARIO", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_INSTALACION(string nombre, string direccion, Nullable<bool> operativa, Nullable<int> id_horario, byte[] imagen, ObjectParameter iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var operativaParameter = operativa.HasValue ?
                new ObjectParameter("operativa", operativa) :
                new ObjectParameter("operativa", typeof(bool));
    
            var id_horarioParameter = id_horario.HasValue ?
                new ObjectParameter("id_horario", id_horario) :
                new ObjectParameter("id_horario", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("imagen", imagen) :
                new ObjectParameter("imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_INSTALACION", nombreParameter, direccionParameter, operativaParameter, id_horarioParameter, imagenParameter, iD, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_PERFIL(string perfil, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var perfilParameter = perfil != null ?
                new ObjectParameter("perfil", perfil) :
                new ObjectParameter("perfil", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_PERFIL", perfilParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_USUARIO(string nombre, string apellido1, string apellido2, string dni, string email, string password, Nullable<int> id_perfil, byte[] imagen, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellido1Parameter = apellido1 != null ?
                new ObjectParameter("apellido1", apellido1) :
                new ObjectParameter("apellido1", typeof(string));
    
            var apellido2Parameter = apellido2 != null ?
                new ObjectParameter("apellido2", apellido2) :
                new ObjectParameter("apellido2", typeof(string));
    
            var dniParameter = dni != null ?
                new ObjectParameter("dni", dni) :
                new ObjectParameter("dni", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var id_perfilParameter = id_perfil.HasValue ?
                new ObjectParameter("id_perfil", id_perfil) :
                new ObjectParameter("id_perfil", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("imagen", imagen) :
                new ObjectParameter("imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_USUARIO", nombreParameter, apellido1Parameter, apellido2Parameter, dniParameter, emailParameter, passwordParameter, id_perfilParameter, imagenParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_LOGIN(string email, string password, ObjectParameter iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_LOGIN", emailParameter, passwordParameter, iD, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_USUARIO(Nullable<int> iD_USUARIO, string nOMBRE, string aPELLIDO1, string aPELLIDO2, Nullable<int> iD_PERFIL, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var aPELLIDO1Parameter = aPELLIDO1 != null ?
                new ObjectParameter("APELLIDO1", aPELLIDO1) :
                new ObjectParameter("APELLIDO1", typeof(string));
    
            var aPELLIDO2Parameter = aPELLIDO2 != null ?
                new ObjectParameter("APELLIDO2", aPELLIDO2) :
                new ObjectParameter("APELLIDO2", typeof(string));
    
            var iD_PERFILParameter = iD_PERFIL.HasValue ?
                new ObjectParameter("ID_PERFIL", iD_PERFIL) :
                new ObjectParameter("ID_PERFIL", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_USUARIO", iD_USUARIOParameter, nOMBREParameter, aPELLIDO1Parameter, aPELLIDO2Parameter, iD_PERFILParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_DELETE_RESERVA(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_RESERVA", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_DELETE_INSTALACION(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_INSTALACION", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_PISTA(string nombre, Nullable<int> id_instalacion, Nullable<bool> operativa, Nullable<int> id_tarifa, Nullable<int> id_actividad, ObjectParameter iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_instalacionParameter = id_instalacion.HasValue ?
                new ObjectParameter("id_instalacion", id_instalacion) :
                new ObjectParameter("id_instalacion", typeof(int));
    
            var operativaParameter = operativa.HasValue ?
                new ObjectParameter("operativa", operativa) :
                new ObjectParameter("operativa", typeof(bool));
    
            var id_tarifaParameter = id_tarifa.HasValue ?
                new ObjectParameter("id_tarifa", id_tarifa) :
                new ObjectParameter("id_tarifa", typeof(int));
    
            var id_actividadParameter = id_actividad.HasValue ?
                new ObjectParameter("id_actividad", id_actividad) :
                new ObjectParameter("id_actividad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_PISTA", nombreParameter, id_instalacionParameter, operativaParameter, id_tarifaParameter, id_actividadParameter, iD, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_RESERVA(string fecha, string h_ini, string h_fin, Nullable<int> id_pista, Nullable<int> id_usuario, string created_at, string updated_at, Nullable<int> id_estado, Nullable<decimal> precio, Nullable<decimal> horas, ObjectParameter iD_RESERVA, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var fechaParameter = fecha != null ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(string));
    
            var h_iniParameter = h_ini != null ?
                new ObjectParameter("h_ini", h_ini) :
                new ObjectParameter("h_ini", typeof(string));
    
            var h_finParameter = h_fin != null ?
                new ObjectParameter("h_fin", h_fin) :
                new ObjectParameter("h_fin", typeof(string));
    
            var id_pistaParameter = id_pista.HasValue ?
                new ObjectParameter("id_pista", id_pista) :
                new ObjectParameter("id_pista", typeof(int));
    
            var id_usuarioParameter = id_usuario.HasValue ?
                new ObjectParameter("id_usuario", id_usuario) :
                new ObjectParameter("id_usuario", typeof(int));
    
            var created_atParameter = created_at != null ?
                new ObjectParameter("created_at", created_at) :
                new ObjectParameter("created_at", typeof(string));
    
            var updated_atParameter = updated_at != null ?
                new ObjectParameter("updated_at", updated_at) :
                new ObjectParameter("updated_at", typeof(string));
    
            var id_estadoParameter = id_estado.HasValue ?
                new ObjectParameter("id_estado", id_estado) :
                new ObjectParameter("id_estado", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var horasParameter = horas.HasValue ?
                new ObjectParameter("horas", horas) :
                new ObjectParameter("horas", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_RESERVA", fechaParameter, h_iniParameter, h_finParameter, id_pistaParameter, id_usuarioParameter, created_atParameter, updated_atParameter, id_estadoParameter, precioParameter, horasParameter, iD_RESERVA, rETCODE, mENSAJE);
        }
    }
}
