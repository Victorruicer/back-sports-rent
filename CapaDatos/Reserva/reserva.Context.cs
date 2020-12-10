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
    
        public virtual int PA_MODIFICAR_USUARIO(Nullable<int> iD_USUARIO, string nOMBRE, string aPELLIDO1, string aPELLIDO2, Nullable<int> iD_PERFIL, byte[] iMAGEN, ObjectParameter rETCODE, ObjectParameter mENSAJE)
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
    
            var iMAGENParameter = iMAGEN != null ?
                new ObjectParameter("IMAGEN", iMAGEN) :
                new ObjectParameter("IMAGEN", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_USUARIO", iD_USUARIOParameter, nOMBREParameter, aPELLIDO1Parameter, aPELLIDO2Parameter, iD_PERFILParameter, iMAGENParameter, rETCODE, mENSAJE);
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
    
        public virtual int PA_DELETE_PISTA(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_PISTA", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_INSTALACION(Nullable<int> iD_INSTALACION, string nOMBRE, string dIRECCION, Nullable<bool> oPERATIVA, Nullable<int> iD_HORARIO, byte[] iMAGEN, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_INSTALACIONParameter = iD_INSTALACION.HasValue ?
                new ObjectParameter("ID_INSTALACION", iD_INSTALACION) :
                new ObjectParameter("ID_INSTALACION", typeof(int));
    
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var dIRECCIONParameter = dIRECCION != null ?
                new ObjectParameter("DIRECCION", dIRECCION) :
                new ObjectParameter("DIRECCION", typeof(string));
    
            var oPERATIVAParameter = oPERATIVA.HasValue ?
                new ObjectParameter("OPERATIVA", oPERATIVA) :
                new ObjectParameter("OPERATIVA", typeof(bool));
    
            var iD_HORARIOParameter = iD_HORARIO.HasValue ?
                new ObjectParameter("ID_HORARIO", iD_HORARIO) :
                new ObjectParameter("ID_HORARIO", typeof(int));
    
            var iMAGENParameter = iMAGEN != null ?
                new ObjectParameter("IMAGEN", iMAGEN) :
                new ObjectParameter("IMAGEN", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_INSTALACION", iD_INSTALACIONParameter, nOMBREParameter, dIRECCIONParameter, oPERATIVAParameter, iD_HORARIOParameter, iMAGENParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_PISTA(Nullable<int> iD_PISTA, string nOMBRE, Nullable<int> iD_INSTALACION, Nullable<bool> oPERATIVA, Nullable<int> iD_TARIFA, Nullable<int> iD_ACTIVIDAD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_PISTAParameter = iD_PISTA.HasValue ?
                new ObjectParameter("ID_PISTA", iD_PISTA) :
                new ObjectParameter("ID_PISTA", typeof(int));
    
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var iD_INSTALACIONParameter = iD_INSTALACION.HasValue ?
                new ObjectParameter("ID_INSTALACION", iD_INSTALACION) :
                new ObjectParameter("ID_INSTALACION", typeof(int));
    
            var oPERATIVAParameter = oPERATIVA.HasValue ?
                new ObjectParameter("OPERATIVA", oPERATIVA) :
                new ObjectParameter("OPERATIVA", typeof(bool));
    
            var iD_TARIFAParameter = iD_TARIFA.HasValue ?
                new ObjectParameter("ID_TARIFA", iD_TARIFA) :
                new ObjectParameter("ID_TARIFA", typeof(int));
    
            var iD_ACTIVIDADParameter = iD_ACTIVIDAD.HasValue ?
                new ObjectParameter("ID_ACTIVIDAD", iD_ACTIVIDAD) :
                new ObjectParameter("ID_ACTIVIDAD", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_PISTA", iD_PISTAParameter, nOMBREParameter, iD_INSTALACIONParameter, oPERATIVAParameter, iD_TARIFAParameter, iD_ACTIVIDADParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_DELETE_ACTIVIDAD(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_ACTIVIDAD", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_DELETE_HORARIO(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_HORARIO", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_DELETE_TARIFA(Nullable<int> iD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DELETE_TARIFA", iDParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_ACTIVIDAD(string actividad, string tipo_pista, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var actividadParameter = actividad != null ?
                new ObjectParameter("actividad", actividad) :
                new ObjectParameter("actividad", typeof(string));
    
            var tipo_pistaParameter = tipo_pista != null ?
                new ObjectParameter("tipo_pista", tipo_pista) :
                new ObjectParameter("tipo_pista", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_ACTIVIDAD", actividadParameter, tipo_pistaParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_HORARIO(string nombre, string horario, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var horarioParameter = horario != null ?
                new ObjectParameter("horario", horario) :
                new ObjectParameter("horario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_HORARIO", nombreParameter, horarioParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_TARIFA(string tarifa, Nullable<decimal> valor, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var tarifaParameter = tarifa != null ?
                new ObjectParameter("tarifa", tarifa) :
                new ObjectParameter("tarifa", typeof(string));
    
            var valorParameter = valor.HasValue ?
                new ObjectParameter("valor", valor) :
                new ObjectParameter("valor", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_TARIFA", tarifaParameter, valorParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_TARIFA(Nullable<int> iD_TARIFA, string tARIFA, Nullable<decimal> vALOR, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_TARIFAParameter = iD_TARIFA.HasValue ?
                new ObjectParameter("ID_TARIFA", iD_TARIFA) :
                new ObjectParameter("ID_TARIFA", typeof(int));
    
            var tARIFAParameter = tARIFA != null ?
                new ObjectParameter("TARIFA", tARIFA) :
                new ObjectParameter("TARIFA", typeof(string));
    
            var vALORParameter = vALOR.HasValue ?
                new ObjectParameter("VALOR", vALOR) :
                new ObjectParameter("VALOR", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_TARIFA", iD_TARIFAParameter, tARIFAParameter, vALORParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_PISTA(string nombre, Nullable<int> id_instalacion, Nullable<bool> operativa, Nullable<int> id_tarifa, Nullable<int> id_actividad, ObjectParameter rETCODE, ObjectParameter mENSAJE)
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
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_PISTA", nombreParameter, id_instalacionParameter, operativaParameter, id_tarifaParameter, id_actividadParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_RESERVA(Nullable<int> iD_RESERVA, string fECHA, string h_INI, string h_FIN, Nullable<int> iD_PISTA, Nullable<int> iD_ESTADO, Nullable<decimal> pRECIO, Nullable<decimal> hORAS, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_RESERVAParameter = iD_RESERVA.HasValue ?
                new ObjectParameter("ID_RESERVA", iD_RESERVA) :
                new ObjectParameter("ID_RESERVA", typeof(int));
    
            var fECHAParameter = fECHA != null ?
                new ObjectParameter("FECHA", fECHA) :
                new ObjectParameter("FECHA", typeof(string));
    
            var h_INIParameter = h_INI != null ?
                new ObjectParameter("H_INI", h_INI) :
                new ObjectParameter("H_INI", typeof(string));
    
            var h_FINParameter = h_FIN != null ?
                new ObjectParameter("H_FIN", h_FIN) :
                new ObjectParameter("H_FIN", typeof(string));
    
            var iD_PISTAParameter = iD_PISTA.HasValue ?
                new ObjectParameter("ID_PISTA", iD_PISTA) :
                new ObjectParameter("ID_PISTA", typeof(int));
    
            var iD_ESTADOParameter = iD_ESTADO.HasValue ?
                new ObjectParameter("ID_ESTADO", iD_ESTADO) :
                new ObjectParameter("ID_ESTADO", typeof(int));
    
            var pRECIOParameter = pRECIO.HasValue ?
                new ObjectParameter("PRECIO", pRECIO) :
                new ObjectParameter("PRECIO", typeof(decimal));
    
            var hORASParameter = hORAS.HasValue ?
                new ObjectParameter("HORAS", hORAS) :
                new ObjectParameter("HORAS", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_RESERVA", iD_RESERVAParameter, fECHAParameter, h_INIParameter, h_FINParameter, iD_PISTAParameter, iD_ESTADOParameter, pRECIOParameter, hORASParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_INSERT_RESERVA(string fecha, string h_ini, string h_fin, Nullable<int> id_pista, Nullable<int> id_usuario, Nullable<int> id_estado, Nullable<decimal> precio, Nullable<decimal> horas, ObjectParameter iD_RESERVA, ObjectParameter rETCODE, ObjectParameter mENSAJE)
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
    
            var id_estadoParameter = id_estado.HasValue ?
                new ObjectParameter("id_estado", id_estado) :
                new ObjectParameter("id_estado", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var horasParameter = horas.HasValue ?
                new ObjectParameter("horas", horas) :
                new ObjectParameter("horas", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_INSERT_RESERVA", fechaParameter, h_iniParameter, h_finParameter, id_pistaParameter, id_usuarioParameter, id_estadoParameter, precioParameter, horasParameter, iD_RESERVA, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_ACTIVIDAD(Nullable<int> iD_ACTIVIDAD, string aCTIVIDAD, string tIPO_PISTA, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_ACTIVIDADParameter = iD_ACTIVIDAD.HasValue ?
                new ObjectParameter("ID_ACTIVIDAD", iD_ACTIVIDAD) :
                new ObjectParameter("ID_ACTIVIDAD", typeof(int));
    
            var aCTIVIDADParameter = aCTIVIDAD != null ?
                new ObjectParameter("ACTIVIDAD", aCTIVIDAD) :
                new ObjectParameter("ACTIVIDAD", typeof(string));
    
            var tIPO_PISTAParameter = tIPO_PISTA != null ?
                new ObjectParameter("TIPO_PISTA", tIPO_PISTA) :
                new ObjectParameter("TIPO_PISTA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_ACTIVIDAD", iD_ACTIVIDADParameter, aCTIVIDADParameter, tIPO_PISTAParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_MODIFICAR_HORARIO(Nullable<int> iD_HORARIO, string nOMBRE, string hORARIO, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iD_HORARIOParameter = iD_HORARIO.HasValue ?
                new ObjectParameter("ID_HORARIO", iD_HORARIO) :
                new ObjectParameter("ID_HORARIO", typeof(int));
    
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var hORARIOParameter = hORARIO != null ?
                new ObjectParameter("HORARIO", hORARIO) :
                new ObjectParameter("HORARIO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_MODIFICAR_HORARIO", iD_HORARIOParameter, nOMBREParameter, hORARIOParameter, rETCODE, mENSAJE);
        }
    
        public virtual int PA_CAMBIO_PASSWORD(Nullable<int> iD, string oLD_PASSWORD, string nEW_PASSWORD, ObjectParameter rETCODE, ObjectParameter mENSAJE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var oLD_PASSWORDParameter = oLD_PASSWORD != null ?
                new ObjectParameter("OLD_PASSWORD", oLD_PASSWORD) :
                new ObjectParameter("OLD_PASSWORD", typeof(string));
    
            var nEW_PASSWORDParameter = nEW_PASSWORD != null ?
                new ObjectParameter("NEW_PASSWORD", nEW_PASSWORD) :
                new ObjectParameter("NEW_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_CAMBIO_PASSWORD", iDParameter, oLD_PASSWORDParameter, nEW_PASSWORDParameter, rETCODE, mENSAJE);
        }
    }
}
