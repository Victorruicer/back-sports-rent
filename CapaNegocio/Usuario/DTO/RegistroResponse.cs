﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Usuario.DTO
{
    public class RegistroResponse
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Email { get; set; }
        public string Mensaje { get; set; }
        public int Retcode { get; set; }
    }
}
