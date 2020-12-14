using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Instalacion.DTO
{
    public class UpdateInstRequest
    {
        public int Id_instalacion { get; set; }
        public string Instalacion { get; set; }
        public string Direccion { get; set; }
        public Boolean Operativa { get; set; }
        public int Id_horario { get; set; }
        public string Imagen { get; set; }
    }
}
