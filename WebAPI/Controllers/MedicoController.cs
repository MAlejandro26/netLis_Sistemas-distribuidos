using Aplicacion.Medicos;
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
    public class MedicoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblMedico>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblMedico>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.MedicoUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data)
        {
            data.IdMedico = id;
            return await Mediator.Send(data);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id, Eliminar.Ejecuta data)
        {
            data.IdMedico = id;
            return await Mediator.Send(data);
        }

    }
}
