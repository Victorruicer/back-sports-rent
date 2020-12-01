using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Instalacion.DTO
{
    public class UpdateInstRequest
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Operativa { get; set; }
        public int Id_horario { get; set; }
    }
}
