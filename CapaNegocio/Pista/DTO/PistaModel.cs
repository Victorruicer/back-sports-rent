using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Pista.DTO
{
    public class PistaModel
    {
        public string Pista { get; set; }
        public string Instalacion { get; set; }
        public string Horario { get; set; }
        public string Actividad { get; set; }
        public string Tipo_pista { get; set; }
        public decimal Precio_hora { get; set; }
        public string Mensaje { get; set; }
    }
}
