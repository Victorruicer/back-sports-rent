using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio.Horario;
using CapaNegocio.Horario.DTO;

namespace WSReservas.Controllers
{
    public class HorarioController : ApiController
    {
        //CREATE
        [HttpPost]
        [Route("createHorario")]
        public HttpResponseMessage createHorario(CreateHorarioRequest newHorario)
        {
            var HorarioDA = new HorarioDataAccess();
            var HorarioCreado = HorarioDA.CreateHorario(newHorario);
            return Request.CreateResponse(HttpStatusCode.OK, HorarioCreado);
        }

        //UPDATE
        [HttpPost]
        [Route("updateHorario")]
        public HttpResponseMessage UpdateHorario(UpdateHorarioRequest upHorario)
        {
            var HorarioDA = new HorarioDataAccess();
            var HorarioUpdateado = HorarioDA.UpdateHorario(upHorario);
            return Request.CreateResponse(HttpStatusCode.OK, HorarioUpdateado);
        }

        //DELETE
        [HttpPost]
        [Route("deleteHorario")]
        public HttpResponseMessage deleteHorario(DeleteHorarioRequest delHorario)
        {
            var HorarioDA = new HorarioDataAccess();
            var HorarioEliminado = HorarioDA.DeleteHorario(delHorario);
            return Request.CreateResponse(HttpStatusCode.OK, HorarioEliminado);
        }

        //LIST
        [HttpGet]
        [Route("listHorarios")]
        public HttpResponseMessage listHorarios()
        {
            var HorarioDA = new HorarioDataAccess();
            var listHorarios = HorarioDA.GetHorarios();
            return Request.CreateResponse(HttpStatusCode.OK, listHorarios);
        }

    }
}
