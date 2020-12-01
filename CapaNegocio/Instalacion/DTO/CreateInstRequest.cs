using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Instalacion.DTO
{
    public class CreateInstRequest
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Operativa { get; set; }
        public int Id_Horario { get; set; }
        public string Imagen { get; set; }
    }
}
