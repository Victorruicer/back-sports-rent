using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Usuario.DTO
{
    public class RegistroRequest
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public int Id_perfil { get; set; }
        public string Imagen { get; set; }
        public string Password { get; set; }
    }
}
