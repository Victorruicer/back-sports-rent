using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Actividad.DTO
{
    public class CreateActividadRequest
    {
        public string Actividad { get; set; }
        public string Tipo_pista { get; set; }
    }
}
