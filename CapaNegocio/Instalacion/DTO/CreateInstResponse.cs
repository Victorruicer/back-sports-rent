using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Instalacion.DTO
{
    public class CreateInstResponse
    {
        public int Id_Instalacion { get; set; }
        public int Retcode { get; set; }
        public string Mensaje { get; set; }
    }
}
