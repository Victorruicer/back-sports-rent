﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Pista.DTO
{
    public class UpdatePistaResponse
    {
        public string Nombre { get; set; }
        public int Retcode { get; set; }
        public string Mensaje { get; set; }
    }
}