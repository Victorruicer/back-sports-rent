using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Instalacion.DTO
{
    public class InstModel
    {
        public string Direccion { get; set; }
        public string Horario { get; set; }
        public string Imagen { get; set; }
        public byte[] Imgtmp { get; set; }
        public int Id_instalacion { get; set; }
        public string Instalacion { get; set; }
        public Boolean Operativa { get; set; }
        public string Mensaje { get; set; }
    }
}
