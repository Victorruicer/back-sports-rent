using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CapaNegocio.Reserva;
using CapaNegocio.Reserva.DTO;

namespace WSReservas.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/reserva")]
    public class ReservaController : ApiController
    {
        //CREATE
        [HttpPost]
        [Authorize]
        [Route("createReserva")]
        public HttpResponseMessage createUser(CreateReservaRequest nuevaReserva)
        {
            var reservaDA = new ReservaDataAccess();
            var reserva = reservaDA.CreateReserva(nuevaReserva);
            return Request.CreateResponse(HttpStatusCode.OK, reserva);
        }
    }
}
