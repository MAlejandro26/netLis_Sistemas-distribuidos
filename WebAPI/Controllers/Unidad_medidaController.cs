﻿using Aplicacion.UnidadMedidas;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Unidad_medidaController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatUnidadMedida>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatUnidadMedida>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.UnidadMedidadUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

    }
}