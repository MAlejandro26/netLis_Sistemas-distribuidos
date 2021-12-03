using Aplicacion.Sexos;
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
    public class SexoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatSexo>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatSexo>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.SexoUnico { Id = id });
        }

        [HttpPost("nuevo")]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data)
        {
            data.IdSexo = id;
            return await Mediator.Send(data);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id, Eliminar.Ejecuta data)
        {
            data.IdSexo = id;
            return await Mediator.Send(data);
        }
    }
}
