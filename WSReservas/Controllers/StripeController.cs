using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CapaNegocio.Pago.DTO;
using Stripe;

namespace WSReservas.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/gestionPago")]
    public class StripeController : ApiController
    {

        [HttpPost]
        [Route("checkout")]
        public HttpResponseMessage PostPago(StripeModel stripeToken)
        {
            StripeConfiguration.ApiKey = "";

            var options = new ChargeCreateOptions
            {
                Amount = 10,
                Currency = "eur",
                Description = "Charge for eduardoruizconde@hotmail.com",
                Source = "sk_test_51Hyg3jC5SO2pUrdtbQh5XcUaFWkN4uN7m4nnFYWoGeaObNsHK9mGCXqIBi1gGG8hk8rhzLjrVqiTsdNGbEIHI4R800pwXtlMoa",

            };

            var service = new ChargeService();
            var url = service.BaseUrl;
            var charge = service.Create(options, new RequestOptions
            {

            });

            return Request.CreateResponse(HttpStatusCode.OK, charge);
        }
    }
}
