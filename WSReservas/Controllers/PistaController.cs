using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CapaNegocio.Pista;
using CapaNegocio.Pista.DTO;

namespace WSReservas.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/pista")]
    public class PistaController : ApiController
    {
        //PISTAS PARA RESERVAR
        [HttpPost]
        [Route("pistasReserva")]
        public HttpResponseMessage pistasReserva(PistasReservaRequest datos)
        {
            var PistaDA = new PistaDataAccess();
            var Pistas = PistaDA.pistasParaReserva(datos);
            return Request.CreateResponse(HttpStatusCode.OK, Pistas);
        }

        
        //CREATE
        [HttpPost]
        [Route("createPista")]
        public HttpResponseMessage createPista(CreatePistaRequest newPista)
        {
            var PistaDA = new PistaDataAccess();
            var PistaCreada = PistaDA.CreatePista(newPista);
            return Request.CreateResponse(HttpStatusCode.OK, PistaCreada);
        }
        /*
        //UPDATE
        [HttpPost]
        [Route("updatePista")]
        public HttpResponseMessage UpdatePista(UpdatePistaRequest upPista)
        {
            var PistaDA = new PistaDataAccess();
            var PistaUpdateada = PistaDA.UpdatePista(upPista);
            return Request.CreateResponse(HttpStatusCode.OK, PistaUpdateada);
        }
        */
        //DELETE
        [HttpPost]
        [Route("deletePista")]
        public HttpResponseMessage deletePista(DeletePistaRequest delPista)
        {
            var PistaDA = new PistaDataAccess();
            var PistaEliminada = PistaDA.DeletePista(delPista);
            return Request.CreateResponse(HttpStatusCode.OK, PistaEliminada);
        }

        //LIST
        [HttpGet]
        [Route("listPistas")]
        public HttpResponseMessage listPistas()
        {
            var PistaDA = new PistaDataAccess();
            var listPistas = PistaDA.GetPistas();
            return Request.CreateResponse(HttpStatusCode.OK, listPistas);
        }
        
    }
}
