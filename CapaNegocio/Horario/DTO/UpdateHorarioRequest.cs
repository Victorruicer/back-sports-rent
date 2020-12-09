using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Horario.DTO
{
    public class UpdateHorarioRequest
    {
        public int Id_horario { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
    }
}
