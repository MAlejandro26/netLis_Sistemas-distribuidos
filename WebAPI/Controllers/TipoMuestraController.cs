﻿using Aplicacion.TipoMuestras;
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
    public class TipoMuestraController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatTipoMuestra>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatTipoMuestra>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.CatTipoMuestraUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data)
        {
            data.IdTipoMuestra = id;
            return await Mediator.Send(data);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id, Eliminar.Ejecuta data)
        {
            data.IdTipoMuestra = id;
            return await Mediator.Send(data);
        }
    }
}