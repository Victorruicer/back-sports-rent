using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CapaNegocio.Instalacion;
using CapaNegocio.Instalacion.DTO;

namespace WSReservas.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/instalacion")]
    public class InstController : ApiController
    {

        //CREATE
        [HttpPost]
        [Route("createInst")]
        public HttpResponseMessage createInst(CreateInstRequest newUser)
        {
            var instDA = new InstDataAccess();
            var instCreada = instDA.CreateInst(newUser);
            return Request.CreateResponse(HttpStatusCode.OK, instCreada);
        }

        ////UPDATE
        //[HttpPost]
        //[Route("updateInst")]
        //public HttpResponseMessage UpdateInst(UpdateInstRequest upInst)
        //{
        //    var instDA = new InstDataAccess();
        //    var instUpdateada = instDA.UpdateInst(upInst);
        //    return Request.CreateResponse(HttpStatusCode.OK, instUpdateada);
        //}

        //DELETE
        [HttpPost]
        [Route("deleteInst")]
        public HttpResponseMessage deleteInst(DeleteInstRequest delInst)
        {
           var instDA = new InstDataAccess();
            var instEliminada = instDA.DeleteInst(delInst);
           return Request.CreateResponse(HttpStatusCode.OK, instEliminada);
        }

        ////LIST
        //[HttpGet]
        //[Route("listInst")]
        //public HttpResponseMessage listInsts()
        //{
        //    var instDA = new InstDataAccess();
        //    var listInsts = instDA.GetInsts();
        //    return Request.CreateResponse(HttpStatusCode.OK, listInsts);
        //}

    }
}
