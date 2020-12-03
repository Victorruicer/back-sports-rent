using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Usuario.DTO
{
    public class UpdateUserRequest
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Id_Perfil { get; set; }
        public string Imagen { get; set; }
    }
}
