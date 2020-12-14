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
        public string Instalacion { get; set; }
        public int Id_instalacion { get; set; }
        public int Id_pista { get; set; }
        public int Id_tarifa { get; set; }
        public int Id_actividad { get; set; }
        public Boolean Operativa { get; set; }
        public string Horario { get; set; }
        public string Actividad { get; set; }
        public string Tipo_pista { get; set; }
        public decimal Precio_hora { get; set; }
        public string Mensaje { get; set; }
    }
}
