using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Pista.DTO
{
    public class PistaModel
    {
        public string Nombre { get; set; }
        public int Id_instalacion { get; set; }
        public bool Operativa { get; set; }
        public int Id_pista { get; set; }
        public int Id_tarifa { get; set; }
        public int Id_actividad { get; set; }
        public string Mensaje { get; set; }
    }
}
