﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Pista.DTO
{
    public class PistasReservaResponse
    {
        public string Pista { get; set; }
        public int Id_pista { get; set; }
        public string Horario { get; set; }
        public string Instalacion { get; set; }
        public decimal Precio_hora { get; set; }
        public string[] LibresReservadas { get; set; }
        public string Fecha { get; set; }
        public string H_ini { get; set; }
        public string H_fin { get; set; }
        public int Id_Reserva { get; set; }
        public string Email { get; set; }
        public decimal Precio { get; set; }
        public string Actividad { get; set; }
        public string Tipo_pista { get; set; }
        public string Estado { get; set; }
        public decimal Horas { get; set; }
        public string Mensaje { get; set; }


    }
}
