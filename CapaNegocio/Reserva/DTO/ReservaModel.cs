﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Reserva.DTO
{
    public class ReservaModel
    {
        public string Fecha { get; set; }
        public string H_ini { get; set; }
        public string H_fin { get; set; }
        public int Id_Reserva { get; set; }
        public int Id_Pista { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Estado { get; set; }
        public decimal Precio { get; set; }
        public decimal Horas { get; set; }
        public string Pista  { get; set; }
        public string Email  { get; set; }
    }
}
