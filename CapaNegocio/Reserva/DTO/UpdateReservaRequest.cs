using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Reserva.DTO
{
    public class UpdateReservaRequest
    {
        public int Id_reserva { get; set; }
        public string Fecha { get; set; }
        public string H_ini { get; set; }
        public string H_fin { get; set; }
        public int Id_pista { get; set; }
        public int Id_estado { get; set; }
        public decimal Precio { get; set; }
        public decimal Horas { get; set; }
    }
}
