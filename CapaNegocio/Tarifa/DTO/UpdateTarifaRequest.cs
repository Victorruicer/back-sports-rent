using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Tarifa.DTO
{
    public class UpdateTarifaRequest
    {
        public int Id_Tarifa { get; set; }
        public string Tarifa { get; set; }
        public decimal Valor { get; set; }
    }
}
