using Aplicacion.Religion;
using Dominio;
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
    public class ReligionController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatReligion>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatReligion>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.ReligionUnica { Id = id });
        }

        [HttpPost("nuevo")]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

    }
}
