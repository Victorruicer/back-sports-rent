﻿using System;
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
        [Route("createReserva")]
        public HttpResponseMessage createReserva(CreateReservaRequest nuevaReserva)
        {
            var reservaDA = new ReservaDataAccess();
            var reserva = reservaDA.CreateReserva(nuevaReserva);
            return Request.CreateResponse(HttpStatusCode.OK, reserva);
        }

        //UPDATE
        [HttpPost]
        [Route("updateReserva")]
        public HttpResponseMessage UpdateReserva(UpdateReservaRequest upReserva)
        {
            var ReservaDA = new ReservaDataAccess();
            var ReservaUpdateada = ReservaDA.UpdateReserva(upReserva);
            return Request.CreateResponse(HttpStatusCode.OK, ReservaUpdateada);
        }

        //LIST
        [HttpGet]
        [Route("listReserva")]
        public HttpResponseMessage listReserva()
        {
            var reservasDA = new ReservaDataAccess();
            var reservas = reservasDA.GetReservas();
            return Request.CreateResponse(HttpStatusCode.OK, reservas);
        }

        //DELETE
        [HttpPost]
        [Route("deleteReserva")]
        public HttpResponseMessage deleteReserva(DeleteReservaRequest delReserva)
        {
            var reservaDA = new ReservaDataAccess();
            var reservaEliminada = reservaDA.DeleteReserva(delReserva);
            return Request.CreateResponse(HttpStatusCode.OK, reservaEliminada);
        }

        //HISTORICO RESERVAS
        [HttpPost]
        [Route("historico")]
        public HttpResponseMessage historicoReservas(HistoricoReservasRequest datos)
        {
            var reservaDA = new ReservaDataAccess();
            var listaReservas = reservaDA.HistoricoReservas(datos);
            return Request.CreateResponse(HttpStatusCode.OK, listaReservas);
        }

    }
}
