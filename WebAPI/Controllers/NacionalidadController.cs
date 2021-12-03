using Aplicacion.Nacionalidad;
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
    public class NacionalidadController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatNacionalidad>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatNacionalidad>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.NacionalidadUnica { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new Eliminar.Ejecuta { IdNacionalidad= id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data)
        {
            data.IdNacionalidad = id;

            return await Mediator.Send(data);
        }
    }
}
