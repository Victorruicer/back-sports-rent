using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CapaNegocio.Actividad;
using CapaNegocio.Actividad.DTO;

namespace WSReservas.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/actividad")]
    public class ActividadController : ApiController
    {

        //CREATE
        [HttpPost]
        [Route("createActividad")]
        public HttpResponseMessage createActividad(CreateActividadRequest newActividad)
        {
            var ActividadDA = new ActividadDataAccess();
            var ActividadCreada = ActividadDA.CreateActividad(newActividad);
            return Request.CreateResponse(HttpStatusCode.OK, ActividadCreada);
        }

        //UPDATE
        [HttpPost]
        [Route("updateActividad")]
        public HttpResponseMessage UpdateActividad(UpdateActividadRequest upActividad)
        {
            var ActividadDA = new ActividadDataAccess();
            var ActividadUpdateada = ActividadDA.UpdateActividad(upActividad);
            return Request.CreateResponse(HttpStatusCode.OK, ActividadUpdateada);
        }

        //DELETE
        [HttpPost]
        [Route("deleteActividad")]
        public HttpResponseMessage deleteActividad(DeleteActividadRequest delActividad)
        {
            var ActividadDA = new ActividadDataAccess();
            var ActividadEliminada = ActividadDA.DeleteActividad(delActividad);
            return Request.CreateResponse(HttpStatusCode.OK, ActividadEliminada);
        }

        //LIST
        [HttpGet]
        [Route("listActividades")]
        public HttpResponseMessage listActividades()
        {
            var ActividadDA = new ActividadDataAccess();
            var listActividades = ActividadDA.GetActividades();
            return Request.CreateResponse(HttpStatusCode.OK, listActividades);
        }

    }
}
