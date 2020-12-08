using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CapaNegocio.Tarifa;
using CapaNegocio.Tarifa.DTO;

namespace WSReservas.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/tarifa")]
    public class TarifaController : ApiController
    {
        /*
        //CREATE
        [HttpPost]
        [Route("createTarifa")]
        public HttpResponseMessage createTarifa(CreateTarifaRequest newTarifa)
        {
            var TarifaDA = new TarifaDataAccess();
            var TarifaCreada = TarifaDA.CreateTarifa(newTarifa);
            return Request.CreateResponse(HttpStatusCode.OK, TarifaCreada);
        }
        
        //UPDATE
        [HttpPost]
        [Route("updateTarifa")]
        public HttpResponseMessage UpdateTarifa(UpdateTarifaRequest upTarifa)
        {
            var TarifaDA = new TarifaDataAccess();
            var TarifaUpdateada = TarifaDA.UpdateTarifa(upTarifa);
            return Request.CreateResponse(HttpStatusCode.OK, TarifaUpdateada);
        }
        
        //DELETE
        [HttpPost]
        [Route("deleteTarifa")]
        public HttpResponseMessage deleteTarifa(DeleteTarifaRequest delTarifa)
        {
            var TarifaDA = new TarifaDataAccess();
            var TarifaEliminada = TarifaDA.DeleteTarifa(delTarifa);
            return Request.CreateResponse(HttpStatusCode.OK, TarifaEliminada);
        }

        //LIST
        [HttpGet]
        [Route("listTarifas")]
        public HttpResponseMessage listTarifas()
        {
            var TarifaDA = new TarifaDataAccess();
            var listTarifas = TarifaDA.GetTarifas();
            return Request.CreateResponse(HttpStatusCode.OK, listTarifas);
        }
        */
    }
}
