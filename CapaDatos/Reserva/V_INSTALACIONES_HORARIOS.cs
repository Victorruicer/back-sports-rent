//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class V_INSTALACIONES_HORARIOS
    {
        public string instalacion { get; set; }
        public string direccion { get; set; }
        public byte[] imagen { get; set; }
        public string horario { get; set; }
        public string pista { get; set; }
        public string actividad { get; set; }
        public string tipo_pista { get; set; }
        public decimal precio_hora { get; set; }
        public Nullable<bool> pista_operativa { get; set; }
        public bool instalación_operativa { get; set; }
        public int id_pista { get; set; }
        public int id_instalacion { get; set; }
        public string tarifa { get; set; }
        public int id_tarifa { get; set; }
        public int id_actividad { get; set; }
    }
}
