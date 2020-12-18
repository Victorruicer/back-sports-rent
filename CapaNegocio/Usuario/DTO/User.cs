using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Usuario.DTO
{
    public class User
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public int Id_Perfil { get; set; }
        public string Imagen { get; set; }
        public Boolean Activo { get; set; }
        public string Mensaje { get; set; }
    }
}
