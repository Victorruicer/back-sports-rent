﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Reserva.DTO
{
    public class CreateReservaRequest
    {
        public string Fecha { get; set; }
        public string H_ini { get; set; }
        public string H_fin { get; set; }
        public int Id_Pista { get; set; }
        public int Id_Usuario { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public int Id_Estado { get; set; }
    }
}
