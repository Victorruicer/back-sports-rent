using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CapaNegocio.Pago.DTO
{

    public class StripeModel
    {
        public string Token { get; set; }
        public long precioTotal { get; set; }
    }
}
